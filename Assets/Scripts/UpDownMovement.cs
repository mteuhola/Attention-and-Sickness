using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpDownMovement : MonoBehaviour
{
    
    public InputActionReference moveAction;
    public float moveSpeed = 1.0f;
    public bool buttonPressed;
    public bool buttonPressed1;
   

    private void OnEnable(){
        moveAction.action.Enable();
    }

    private void OnDisable(){
        moveAction.action.Disable();
    }
 
    void Update(){
        Vector2 joystickValue = moveAction.action.ReadValue<Vector2>();
        float verticalInput = joystickValue.y;

        if (verticalInput > 0.5f)
        {
            buttonPressed1 = true;
        }
        else
        {
            buttonPressed1 = false;
        }

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