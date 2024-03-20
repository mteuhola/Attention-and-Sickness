using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    public float updateTime = 6.0f;
    private float Maxtumble = 0.04f;
    private float Mintumble = -0.04f;

    void Start()
    {
        StartCoroutine(ChangeRotationCoroutine());
    }

    IEnumerator ChangeRotationCoroutine(){
        while (true){
        GetComponent<Rigidbody>().angularVelocity = Vector3.up * tumble;
        float speedChange = Random.Range(Mintumble, Maxtumble);
       
        tumble += speedChange;
       
        yield return new WaitForSeconds(updateTime);
        yield return null;
        }
    }
}