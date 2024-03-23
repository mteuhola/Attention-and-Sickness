using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OreCollect : MonoBehaviour
{
    public static int oreCount = 0;
  
 
    public void oreCollect(){
            Destroy(gameObject);
            oreCount++;
    }
}
