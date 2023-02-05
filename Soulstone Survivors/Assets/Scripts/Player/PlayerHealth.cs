using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : LivingEntity, IEnumerator
{
    public GameObject hitEffect;

    private AudioSource playerAudioPlayer; // �÷��̾� �Ҹ� �����
    private Animator playerAnimator; // �÷��̾��� �ִϸ�����

    private PlayerMovement playerMovement; // �÷��̾� ������ ������Ʈ

    public object Current => throw new System.NotImplementedException();

    private void Awake()
    {
        dead = false;
        // ����� ������Ʈ�� ��������
        playerAudioPlayer = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
       // playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        // LivingEntity�� OnEnable() ���� (���� �ʱ�ȭ)
        base.OnEnable();

        playerMovement.enabled = true;
    }

    // ������ ó��
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
    // ��� ó��
    public override void Die()
    {
        // LivingEntity�� Die() ����(��� ����)
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