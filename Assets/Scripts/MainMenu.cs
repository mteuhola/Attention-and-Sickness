using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
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
