using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LivingEntity
{
    public LayerMask playerLayerMask;

    public LivingEntity player;
    private NavMeshAgent navMeshAgent;

    public ParticleSystem hitEffect;

    private Animator enemyAnimator;

    public float speed = 15f;
    public float damage = 20f;
    public float timeBetAttack = 0.5f;
    private float lastAttackTime;

    public float searchRadius = 20f;

    private bool isPlayerAlive
    {
        get
        {
            return player != null && !player.dead;
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }
    public void Setup()
    {
        navMeshAgent.speed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(UpdatePath());
    }
    private IEnumerator UpdatePath()
    {
        while (!dead)
        {

            if (isPlayerAlive)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(player.transform.position);
            }
            else
            {
                navMeshAgent.isStopped = true;

                Collider[] colliders =
                    Physics.OverlapSphere(transform.position, searchRadius, playerLayerMask);

                for (int i = 0; i < colliders.Length; i++)
                {
                    LivingEntity livingEntity = colliders[i].GetComponent<LivingEntity>();

                    if (livingEntity != null && !livingEntity.dead)
                    {
                        player = livingEntity;
                        break;
                    }
                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (dead)
            return;

        hitEffect.transform.position = hitPoint;
        hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
        hitEffect.Play();

        base.OnDamage(damage, hitPoint, hitNormal);
    }
    public override void Die()
    {
        if (dead)
            return;

        base.Die();

        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }

        navMeshAgent.isStopped = true;
        navMeshAgent.enabled = false;

        enemyAnimator.SetTrigger("Die");

        Destroy(gameObject, 5f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (dead || Time.time < lastAttackTime + timeBetAttack)
            return;

        LivingEntity target = other.GetComponent<LivingEntity>();
        if (target != null && target == player)
        {
            lastAttackTime = Time.time;

            Vector3 hitPoint = other.ClosestPoint(transform.position);
            Vector3 hitNormal = transform.position - other.transform.position;

            target.OnDamage(damage, hitPoint, hitNormal);
        }

    }
    void Update()
    {
        //enemyAnimator.SetBool("IsPlayerDead", !isPlayerAlive);
        //enemyAnimator.SetFloat("Forward", 60f);
    }
}
