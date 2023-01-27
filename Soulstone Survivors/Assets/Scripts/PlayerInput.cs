using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string movevAxisName = "Vertical";
    public string moveHAxisName = "Horizontal";
    //public string fireButtonName = "Fire1";

    public float moveV { get; private set; }
    public float moveH { get; private set; }
    public bool fire { get; private set; }
    public Vector3 mousePos { get; private set; }

    void Update()
    {
        moveV = Input.GetAxisRaw(movevAxisName);
        moveH = Input.GetAxisRaw(moveHAxisName);
        //fire = Input.GetButton(fireButtonName);
        mousePos = Input.mousePosition;
    }
}
