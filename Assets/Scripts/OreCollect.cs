using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OreCollect : MonoBehaviour
{
    public static int oreCount = 0;
    public InputActionReference action;
    
   
    private void OnEnable()
    {
        action.action.Enable();
        action.action.performed += OnActionPerformed;
    }

    private void OnDisable()
    {
        action.action.Disable();
        action.action.performed -= OnActionPerformed;
    }
    private void OnActionPerformed(InputAction.CallbackContext context)
    {
        {
            Destroy(gameObject);
            oreCount++;
        }
    }
}
