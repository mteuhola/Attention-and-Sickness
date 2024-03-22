using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpDownMovement : MonoBehaviour
{
    //public InputActionReference action;
    //public InputActionReference action1;
    public InputActionReference moveAction;
    public float moveSpeed = 1.0f;
    public bool buttonPressed;
    public bool buttonPressed1;
   

    private void OnEnable(){
        //action.action.Enable();
        //action1.action.Enable();
        moveAction.action.Enable();
    }

    private void OnDisable(){
        //action.action.Disable();
        //action1.action.Disable();
        moveAction.action.Disable();
    }
 
    void Update(){
        Vector2 joystickValue = moveAction.action.ReadValue<Vector2>();
        float verticalInput = joystickValue.y;

        //if (action.action.ReadValue<float>() > 0.5f)
        if (verticalInput > 0.5f)
        {
            buttonPressed1 = true;
        }
        else
        {
            buttonPressed1 = false;
        }

       //if (action1.action.ReadValue<float>() > 0.5f)
       if (verticalInput < -0.5f)
        {
            buttonPressed = true;
        }
        else
        {
            buttonPressed = false;
        }

        if (buttonPressed1){
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }else
        {
            transform.Translate(Vector3.zero);
        }
        if (buttonPressed){
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }else
        {
            transform.Translate(Vector3.zero);
        }
}
}