using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainScreen, levelScreen;
    
    private static bool _isInitialized;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (!_isInitialized)
        {
            mainScreen.SetActive(true);
            levelScreen.SetActive(false);
            _isInitialized = true;
        }
        else
        {
            mainScreen.SetActive(false);
            levelScreen.SetActive(true);
        }
    }
    
    public void PlayLevelOne()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OpenSsq()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
