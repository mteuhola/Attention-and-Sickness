using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexHandler : MonoBehaviour
{

    public float scaleSpeed = 1.0f;
    public float tumble = 1.0f;
    public float vortexDelay = 20f;
    public bool vortexScaling = false;
    private Vector3 targetScale = new Vector3(10, 10, 10);
    private float startTime;

    void Start(){
        startTime = Time.time;
    }

    void Update()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.back * tumble;
        if (!vortexScaling && Time.time - startTime >= vortexDelay){
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
        }
    }
}