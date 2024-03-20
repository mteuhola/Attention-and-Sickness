using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Timing : MonoBehaviour
{
    public InputActionReference action;
    public TextMeshProUGUI flashing;
    public float flashDelayMin = 9.0f;
    public float flashDelayMax = 12.0f;
    public float lightOnTime = 2.0f;
    public bool lightEvent = false;

    void Start()
    {
        StartCoroutine(FlashRoutine());
 
    }
    
    IEnumerator FlashRoutine()
    {
        while (true)
        {
            
            float flashDelay = Random.Range(flashDelayMin, flashDelayMax);
            yield return new WaitForSeconds(flashDelay);
            flashing.color = Color.red;
            lightEvent = true;
            StartCoroutine(LightOnEvent());
            yield return null;
        }
    }
     IEnumerator LightOnEvent()
    {
        yield return new WaitForSeconds(lightOnTime);
        flashing.color = Color.white;
        lightEvent = false;
    }

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
        if (lightEvent)
        {
            StopCoroutine(LightOnEvent());
            lightEvent = false;
            flashing.color = Color.white;
        }
    }
}