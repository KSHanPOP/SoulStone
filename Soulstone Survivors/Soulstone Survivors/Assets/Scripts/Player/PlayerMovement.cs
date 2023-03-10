using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 55f;
    public float dashSpeed = 0f;
    private bool isDash = false;

    private PlayerInput playerInput;
    public Rigidbody playerRigidbody;
    private Animator playerAnimator;

    private Vector3 inputMove;

    private Animation playerAnimation;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        // playerRigidbody = GetComponentInChildren<Rigidbody>();
        //playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAnimation = GetComponent<Animation>();
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
        var temp = localDir;
        localDir *= (moveSpeed + dashSpeed) * Time.fixedDeltaTime;
        localDir -= temp;
        transform.Translate(localDir);

        // Debug.Log(localDir);
        //if (localDir.x > 1f)
        //{
        //    var x = localDir;
        //    x.x -= 1f;
        //    x.y = 0f;
        //    x.z = 0f;
        //    transform.Translate(x);
        //    Debug.Log(x);
        //}
        //if (localDir.x < -1f)
        //{
        //    var x = localDir;
        //    x.x += 1f;
        //    x.y = 0f;
        //    x.z = 0f;

        //    transform.Translate(x);
        //    Debug.Log(x);
        //}
        //if (localDir.z > 1f)
        //{

        //    var z = localDir;
        //    z.x = 0f;
        //    z.y = 0f;
        //    z.z -= 1f;
        //    transform.Translate(z);
        //    Debug.Log(z);
        //}
        //if (localDir.z < -1f)
        //{

        //    var z = localDir;
        //    z.x = 0f;
        //    z.y = 0f;
        //    z.z += 1f;
        //    Debug.Log(z);
        //    transform.Translate(z);
        //}
        //transform.Translate(delta, Space.World);
        //transform.Translate(delta, Space.World);
        //playerRigidbody.MovePosition(playerRigidbody.transform.position + delta);
        //playerAnimator.SetBool("Run", delta != Vector3.zero);
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

    private void Dash()
    {

        if (playerInput.dash)
        {
            StartCoroutine(Dashing());
        }
    }

    IEnumerator Dashing()
    {
        isDash = true;
        GetComponent<SkinnedMeshAfterImage>().enabled = true;
        dashSpeed = 30f;
        inputMove.x = playerInput.moveV;
        inputMove.z = playerInput.moveH;

        yield return new WaitForSecondsRealtime(0.2f);
        isDash = false;
        GetComponent<SkinnedMeshAfterImage>().enabled = false;
        dashSpeed = 0f;
        playerInput.dash = false;
    }
}
