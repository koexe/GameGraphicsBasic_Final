using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager 
{
    public Action KeyAction = null;
    public Action MouseAction = null;


    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (Input.GetMouseButton(0) && MouseAction != null)
            MouseAction.Invoke();
    }
}
