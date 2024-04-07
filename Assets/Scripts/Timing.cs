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
    public int flashValue;
    public float redFlashMin = 10f;
    public float redFlashMax = 20f;
    public float redFlashRange;
    public float flashRange;
    public bool isRed = false;

    void Start()
    {
        redFlashRange = Mathf.Round(Random.Range(redFlashMin, redFlashMax));
        StartCoroutine(FlashRoutine());
        flashing.text = "O";
        
    }
    
    IEnumerator FlashRoutine()
    {
        while (!isRed)
        {
            StartCoroutine(LightOnEvent());
            flashRange++;
            float flashDelay = Random.Range(flashDelayMin, flashDelayMax);
            yield return new WaitForSeconds(flashDelay);
            flashValue = 1;
            flashing.text = "O";
            

            
            if(flashRange == redFlashRange){
                StopCoroutine(FlashRoutine());
                isRed = true;
                flashing.text = "O";
                lightEvent = true;
                redFlashRange = Mathf.Round(Random.Range(redFlashMin, redFlashMax));
                flashing.color = Color.red;
                flashRange = 0f;
                flashValue = 2;
                Debug.Log(flashValue);
            }
            yield return null;
        }
    }

    IEnumerator LightOnEvent()
    {
        yield return new WaitForSeconds(lightOnTime);
        flashing.text = "";
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
            flashValue = 3;
            Debug.Log(flashValue);
            StopCoroutine(LightOnEvent());
            lightEvent = false;
            flashing.text = "";
            flashing.color = Color.white;
            isRed = false;
            StartCoroutine(FlashRoutine());
        }
        else {
            flashing.color = Color.white;
        }
    }
}