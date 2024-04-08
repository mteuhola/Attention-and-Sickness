using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    // Start is called before the first frame update

    // Time elapsed in the current scene
    public float currentTime = 0f;
    private bool timerRunning = false;
    [SerializeField] private bool enableTimeLimit = false;
    [SerializeField] private int timeLimitSeconds = 300;

    // Start is called before the first frame update
    void Start()
    {
        // Reset timer when a new scene is loaded
        currentTime = 0f;
        // Start the timer
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            currentTime += Time.deltaTime;
        }

        if (enableTimeLimit && currentTime > timeLimitSeconds)
        {
            SceneManager.LoadScene(0);
        }
    }
}
