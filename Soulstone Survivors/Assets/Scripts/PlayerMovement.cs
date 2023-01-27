using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;

    private PlayerInput playerInput;
    public Rigidbody playerRigidbody;
    private Animator playerAnimator;
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
        Rotate();
    }

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

        var delta = dir * moveSpeed * Time.fixedDeltaTime;
        var localDir = transform.InverseTransformDirection(delta);
        playerAnimator.SetFloat("SidewaysMovement", localDir.x );
        playerAnimator.SetFloat("ForwardMovement", localDir.z );
        Debug.Log(localDir);
        //transform.Translate(delta, Space.World);
        //transform.Translate(delta, Space.World);
        //playerRigidbody.MovePosition(playerRigidbody.transform.position + delta);
        //playerAnimator.SetBool("Run", delta != Vector3.zero);
    }

    private void Rotate()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(playerInput.mousePos);
        //Debug.Log(playerInput.mousePos);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            var forward = hit.point - transform.position;
            forward.y = 0f;
            forward.Normalize();

            transform.rotation = Quaternion.LookRotation(forward);
        }
    }
}
