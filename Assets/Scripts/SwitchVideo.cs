using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SwitchVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public OreCollect oreCollect;
    public OreCounter oreCounter;
    public GameObject pickaxe, asteroid, alien ;

    private bool pickActive = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

    }

    public void Update(){
        
        if (oreCollect.oreCount == 5 && oreCounter.killCount < 1){
            videoPlayer.clip = videoClips[2];
            videoPlayer.Play();
            alien.SetActive(true);
    }

        if (pickActive && oreCollect.oreCount < 5){
            
            videoPlayer.clip = videoClips[1];
            videoPlayer.Play();
            asteroid.SetActive(true);
    }
        
        if (pickaxe.activeSelf){
            pickActive = true;
        }

       if (!pickActive){
        videoPlayer.clip = videoClips[0];
        videoPlayer.Play();
        }
    }
}