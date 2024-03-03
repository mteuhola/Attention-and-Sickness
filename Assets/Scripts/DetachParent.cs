using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachParent : MonoBehaviour
{
    public Transform originalParent;
    public Transform camera;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rb;

    void Start()
    {
        originalRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    public void RefreshParent() {

        transform.rotation = originalRotation;
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        transform.LookAt(new Vector3(camera.position.x, transform.position.y, camera.position.z));
    }

    public void Detach() {

        originalParent = transform.parent;
        originalPosition = transform.localPosition;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.SetParent(null);
    }
}
