using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string movevAxisName = "Vertical";
    public string moveHAxisName = "Horizontal";
    public string dashName = "Dash";
    //public string fireButtonName = "Fire1";

    public float moveV { get; private set; }
    public float moveH { get; private set; }
    public bool dash { get; set; }
    public Vector3 mousePos { get; private set; }


    void Update()
    {
        moveV = Input.GetAxisRaw(movevAxisName);
        moveH = Input.GetAxisRaw(moveHAxisName);
        mousePos = Input.mousePosition;

        if (!dash)
        {
            dash = Input.GetButtonDown(dashName);
        }
    }
}
