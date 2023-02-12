using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 300f;
    private float dashSpeed = 1f;
    public float maxDash = 5f;
    private bool isDash = false;

    private PlayerInput playerInput;
    public Rigidbody playerRigidbody;
    private Animator playerAnimator;

    public Scanner scanner;

    private Vector3 inputMove;

    private Animation playerAnimation;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        // playerRigidbody = GetComponentInChildren<Rigidbody>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAnimation = GetComponent<Animation>();
        scanner= GetComponent<Scanner>();
    }

    private void FixedUpdate()
    {

        Move();
        if (playerInput.dash && !isDash)
        {
            StartCoroutine(Dashing());
        }

        Rotate();
    }

    //private void OnAnimatorMove()
    //{
    //    Debug.Log(Time.time);

    //    var forward = Camera.main.transform.forward;
    //    forward.y = 0f;
    //    forward.Normalize();

    //    var right = Camera.main.transform.right;
    //    right.y = 0f;
    //    right.Normalize();

    //    var dir = forward * playerInput.moveV;
    //    dir += right * playerInput.moveH;

    //    if (dir.magnitude > 1f)
    //    {
    //        dir.Normalize();
    //    }

    //    var localDir = transform.InverseTransformDirection(dir);
    //    playerAnimator.SetFloat("SidewaysMovement", localDir.x);
    //    playerAnimator.SetFloat("ForwardMovement", localDir.z);
    //    localDir *= moveSpeed * Time.fixedDeltaTime;
    //    var temp = localDir;
    //    localDir *= moveSpeed * Time.fixedDeltaTime;
    //    localDir -= temp;
    //    transform.Translate(localDir);



    //}
    private void Move()
    {
        var forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        var right = Camera.main.transform.right;
        right.y = 0f;
        right.Normalize();

        var dir = new Vector3();

        if (!playerInput.dash)
        {
            dir = forward * playerInput.moveV;
            dir += right * playerInput.moveH;
        }
        else
        {
            dir = forward * inputMove.x;
            dir += right * inputMove.z;
        }

        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }

        var localDir = transform.InverseTransformDirection(dir);
        playerAnimator.SetFloat("SidewaysMovement", localDir.x);
        playerAnimator.SetFloat("ForwardMovement", localDir.z);
        // var temp = localDir;

        dir *= (moveSpeed) * Time.fixedDeltaTime * dashSpeed;
        playerRigidbody.AddForce(dir);
       // Debug.Log(dir);
    }

    private void Rotate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(playerInput.mousePos);
        //Debug.Log(playerInput.mousePos);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            var forward = hit.point - transform.position;
            forward.y = 0f;
            forward.Normalize();

            transform.rotation = Quaternion.LookRotation(forward);
        }
    }

    IEnumerator Dashing()
    {
        playerAnimator.SetBool("OnGround", false);
        //playerRigidbody.velocity = new Vector3(0f,10f,0f);
        isDash = true;
        GetComponent<SkinnedMeshAfterImage>().enabled = true;
        dashSpeed = maxDash;
        inputMove.x = playerInput.moveV;
        inputMove.z = playerInput.moveH;

        yield return new WaitForSecondsRealtime(0.2f);
        isDash = false;
        playerAnimator.SetBool("OnGround", true);
        //playerRigidbody.velocity = new Vector3(0f, 100f, 0f);

        GetComponent<SkinnedMeshAfterImage>().enabled = false;
        dashSpeed = 1f;
        playerInput.dash = false;
    }
}
