using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OreCounter : MonoBehaviour
{
    public TextMeshProUGUI oreCountText;
    

    void Update()
    {
        oreCountText.text = OreCollect.oreCount.ToString();
    }
}