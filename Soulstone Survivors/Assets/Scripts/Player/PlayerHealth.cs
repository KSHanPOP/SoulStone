using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : LivingEntity, IEnumerator
{
    public GameObject hitEffect;

    private AudioSource playerAudioPlayer; // 플레이어 소리 재생기
    private Animator playerAnimator; // 플레이어의 애니메이터

    private PlayerMovement playerMovement; // 플레이어 움직임 컴포넌트

    public object Current => throw new System.NotImplementedException();

    private void Awake()
    {
        dead = false;
        // 사용할 컴포넌트를 가져오기
        playerAudioPlayer = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
       // playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        // LivingEntity의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();

        playerMovement.enabled = true;
    }

    // 데미지 처리
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        if (dead)
            return;

        base.OnDamage(damage, hitPoint, hitDirection);
        hitEffect.SetActive(true);

        StartCoroutine(Stop());


    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        hitEffect.SetActive(false);
    }
    public float GetHP()
    {
        return health;
    }
    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die() 실행(사망 적용)
        base.Die();

        playerMovement.enabled = false;
        playerAnimator.SetTrigger("Die");

        StartCoroutine(StopGameOver());

        // Invoke(UIManager.Instance.gameoverUI.SetActive(true),5f);

    }
    public IEnumerator StopGameOver()
    {
        yield return new WaitForSeconds(6f);
    }
    public bool MoveNext()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }
}