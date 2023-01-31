using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;

    private PlayerInput playerInput;
    public Rigidbody playerRigidbody;
    private Animator playerAnimator;

    public GameObject DashEffect;

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
        Rotate();
        Move();
        Dash();
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

        var dir = forward * playerInput.moveV;
        dir += right * playerInput.moveH;



        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }

        var localDir = transform.InverseTransformDirection(dir);
        playerAnimator.SetFloat("SidewaysMovement", localDir.x);
        playerAnimator.SetFloat("ForwardMovement", localDir.z);
        var temp = localDir;
        localDir *= moveSpeed * Time.fixedDeltaTime;
        // Debug.Log(localDir);
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

        Debug.Log(playerInput.dash);
        if (playerInput.dash)
            DashEffect.SetActive(true);
            //playerAnimator.SetBool("Dash", true);
    }
}
  