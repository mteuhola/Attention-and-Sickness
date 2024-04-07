using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OreCounter : MonoBehaviour
{
    public GameObject locomotionSystem, oxygenText, collectText, levelCompleteText;

    public int invokeTimer = 5;
    
    public TextMeshProUGUI oreCountText;

    public OreCollect oreCollect;

    public int moonstoneMax = 90, killMax = 10, killCount;

    void Update()
    {
        oreCountText.text = "Moonstones: " + oreCollect.oreCount + "/" + moonstoneMax + "\nAliens shot: " + killCount + "/" + killMax;
        if (oreCollect.oreCount == moonstoneMax && killCount == killMax)
        {
            levelCompleteText.SetActive(true);
            locomotionSystem.SetActive(false);
            oxygenText.SetActive(false);
            collectText.SetActive(false);
            Invoke("ReturnToMenu", invokeTimer);
        }
    }

    public void AddKill()
    {
        killCount++;
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}