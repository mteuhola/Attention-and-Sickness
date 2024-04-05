using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OreCounter : MonoBehaviour
{
    public TextMeshProUGUI oreCountText;

    public OreCollect oreCollect;

    public int killCount;

    void Update()
    {
        oreCountText.text = "Moonstones: " + oreCollect.oreCount + "\nAliens shot: " + killCount;
        if (oreCollect.oreCount == 90 && killCount == 10)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddKill()
    {
        killCount++;
    }
}