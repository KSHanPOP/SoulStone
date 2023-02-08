using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCController : MonoBehaviour
{
    public enum States
    {
        None = -1,
        Idle,
        Chase,
        Attack,
        GameOver,
    }

    public float speed;
    public float chaseSpeed; // current agent speed and NavMeshAgent component speed

    private Transform player; // reference to the player object transform

    private Animator animator; // reference to the animator component
    private NavMeshAgent agent; // reference to the NavMeshAgent

    private float distanceToPlayer;
    public float idleTime = 1f;
    public float chaseInterval = 0.25f;
    private float timer = 0f;
    private float AttIdleTime = 0f;


    private States state = States.None;

    public AttackDefinition attackDef;

    public Transform rightHand;

    private CharacterStats stats;

    public States State
    {
        get { return state; }
        private set
        {
            var prevState = state;
            state = value;

            if (prevState == state)
                return;

            switch (state)
            {
                case States.Idle:
                    timer = 0f;
                    agent.speed = speed;
                    agent.isStopped = true;
                    break;
                case States.Chase:
                    timer = 0f;
                    agent.speed = chaseSpeed;
                    agent.isStopped = false;
                    agent.SetDestination(player.position);
                    break;
                case States.Attack:
                    timer = attackDef.coolDown;
                    agent.isStopped = true;
                    break;
                case States.GameOver:
                    agent.isStopped = true;
                    break;
            }
        }
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        // animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        stats = GetComponent<CharacterStats>();

        //var ev = player.GetComponent<DestructedEvent>();
        //ev.OnDie += OnPlayerDie;
    }
    public void OnPlayerDie()
    {
        State = States.GameOver;
    }
    private void Start()
    {
        State = States.Chase;

        //State = States.Chase;
    }

    private void Update()
    {

        if (State == States.Chase)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.position);
        }

        switch (state)
        {
            case States.Idle:
                UpdateIdle();
                break;
            case States.Chase:
                UpdateChase();
                break;
            case States.Attack:
                UpdateAttack();
                break;
        }

        if (States.Chase == state)
            animator.SetFloat("Forward", agent.velocity.magnitude);

        Debug.Log(state);
    }

    private void UpdateChase()
    {
        timer += Time.deltaTime;
        ///animator.SetBool("AttackIdle", false);

        if (distanceToPlayer < attackDef.range)
        {
            State = States.Attack;
            timer = 0f;

            return;
        }

        if (timer > chaseInterval)
        {
           // agent.enabled = true;

            agent.SetDestination(player.position);
            timer = 0f;
        }
    }



    private void UpdateIdle()
    {
        timer += Time.deltaTime;

        if (animator.GetBool("AttackIdle"))
        {
            //agent.enabled = false;
            //agent.isStopped = true;
            StartCoroutine(Waitting(1f));
            animator.SetBool("AttackIdle", false);
        }

    }

    private void UpdateAttack()
    {
        if (!animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", true);
            animator.SetFloat("Forward", 0f);
        }

        if (animator.GetBool("AttackIdle"))
        {
            State = States.Idle;
            animator.SetBool("Attack", false);
        }





        ////////////////////////////////////////////////////////////////////////
        //AttIdleTime += Time.fixedDeltaTime;

        //if (animator.GetBool("AttackIdle") && AttIdleTime > attackDef.coolDown)
        //{
        //    distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //    AttIdleTime = 0f;

        //    if (distanceToPlayer > attackDef.range)
        //    {
        //        State = States.Chase;
        //        animator.SetTrigger("Chase");

        //        return;
        //    }
        //    else
        //    {
        //        animator.SetBool("AttackIdle", false);
        //    }

        //}

        //if (!animator.GetBool("AttackIdle"))
        //{
        //    var lookPos = player.position;
        //    lookPos.y = transform.position.y;
        //    transform.LookAt(lookPos);

        //    animator.SetTrigger("ExecuteAttack");
        //}

        ////////////////////////////////////////////////////////////////////////

    }
    public void Hit()
    {
        //attackDef.ExecuteAttack(gameObject, player.gameObject);  

        switch (attackDef)
        {
            case Weapon weapon:
                weapon.ExecuteAttack(gameObject, player.gameObject);
                break;
            case Spell spell:
                var pos = player.transform.position;
                pos.y += 1f;
                var layer = LayerMask.NameToLayer("EnemyProjectile");
                spell.Cast(gameObject, rightHand.position, pos, layer);
                break;
        }
    }


    IEnumerator Waitting(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > attackDef.range)
        {
            State = States.Chase;
        }
        else
        {
            State = States.Attack;
        }
    }
}