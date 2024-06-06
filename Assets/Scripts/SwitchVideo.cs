using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public OreCollect oreCollect;
    public OreCounter oreCounter;
    public GameObject pickaxe, asteroid, alien, tutorialTextOne, tutorialTextTwo, tutorialTextThree;
    public ActionBasedContinuousMoveProvider moveProvider;
    public UpDownMovement upDownSystem;

    private bool pickActive = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        tutorialTextOne.SetActive(true);
        tutorialTextTwo.SetActive(false);
        tutorialTextThree.SetActive(false);
    }

    public void Update(){
        
        if (oreCollect.oreCount == 5 && oreCounter.killCount < 1){
            videoPlayer.clip = videoClips[2];
            videoPlayer.Play();
            alien.SetActive(true);
            tutorialTextThree.SetActive(true);
            tutorialTextTwo.SetActive(false);

        }

        if (pickActive && oreCollect.oreCount < 5){
            moveProvider.moveSpeed = 8;
            upDownSystem.moveSpeed = 4;
            videoPlayer.clip = videoClips[1];
            videoPlayer.Play();
            asteroid.SetActive(true);
            tutorialTextTwo.SetActive(true);
            tutorialTextOne.SetActive(false);
        }
        
        if (pickaxe.activeSelf){
            pickActive = true;
        }

       if (!pickActive){
           moveProvider.moveSpeed = 0;
           upDownSystem.moveSpeed = 0;
           videoPlayer.clip = videoClips[0];
           videoPlayer.Play();
        }
    }
}