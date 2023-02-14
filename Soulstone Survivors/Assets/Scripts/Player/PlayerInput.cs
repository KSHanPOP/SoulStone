using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveVAxisName = "Vertical";
    public string moveHAxisName = "Horizontal";
    public string dashName = "Dash";
    //public string fireButtonName = "Fire1";

    public float moveV { get; private set; }
    public float moveH { get; private set; }
    public bool dash { get; set; }
    public Vector3 mousePos { get; private set; }

    public FixedJoystick moveJoy;
    public FixedJoystick dirJoy;
    Vector3 rotation;
    Vector3 curRotation;


    void Update()
    {
        //Input.GetKey(KeyCode.Escape);


        moveH = moveJoy.Horizontal;
        moveV = moveJoy.Vertical;
        rotation = new Vector3(dirJoy.Horizontal, 0, dirJoy.Vertical);
        if (rotation == Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(curRotation);
        }
        else
        {
            curRotation = rotation;
            transform.rotation = Quaternion.LookRotation(rotation);
        }
        //moveV = Input.GetAxisRaw(moveVAxisName);
        //moveH = Input.GetAxisRaw(moveHAxisName);
        //mousePos = Input.mousePosition;

        if (!dash)
        {
            dash = Input.GetButtonDown(dashName);
        }
    }

    public void OnClick()
    {
        dash = true;
    }
}
