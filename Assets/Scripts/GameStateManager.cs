using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject videoPlayerObject;
    
    [SerializeField]
    private VideoClip introVideo;
    
    [SerializeField]
    private VideoClip outroVideo;

    private const int INTRO = 0;
    private const int GAME = 1;
    private const int OUTRO = 2;

    private int currentState;

    VideoHandling videoHandling;

    private RigidbodyFirstPersonController playerController;

    public static GameStateManager gameStateManager;

    private void Awake()
    {
        if (gameStateManager == null) {
            gameStateManager = this;
        }
    }

    private void Start()
    {
        currentState = INTRO;
        videoHandling = videoPlayerObject.GetComponent<VideoHandling>();
        videoHandling.setVideo(introVideo);
        playerController = Player.player.GetComponent<RigidbodyFirstPersonController>();
        playerController.enabled = false;
        StartCoroutine(videoHandling.PlayVideo());
    }

    private void Update()
    {
        if (currentState == INTRO) {
            if (videoHandling.VideoOver()) {
                playerController.enabled = true;
                Player.player.Respawn();
                videoPlayerObject.SetActive(false);
                currentState = GAME;
            }
        }
    }





}
