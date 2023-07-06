using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeOnThreeManager : MonoBehaviour
{
    public GameObject OptionsScreen;
    public GameObject InGameScreen;
    public GameObject PickupPlayScreen;
    public GameObject ChallengeScreen;
    public Button PickupButton;
    public Button ChallengeButton;
    private void OnEnable()
    {
        InitGameMode();
        PickupButton.onClick.AddListener(PlayPickup);
        ChallengeButton.onClick.AddListener(PlayChallenge);
    }

    private void OnDisable()
    {
        PickupButton.onClick.AddListener(PlayPickup);
        ChallengeButton.onClick.AddListener(PlayChallenge);
    }

    private void InitGameMode()
    {
        print("Initializing");
        OptionsScreen.SetActive(true);
        InGameScreen.SetActive(false);
    }
    
    private void ResetGameMode()
    {
        print("Resetting");
        OptionsScreen.SetActive(false);
        InGameScreen.SetActive(false);
    }
    
    private void InGameTransition()
    {
        OptionsScreen.SetActive(false);
        InGameScreen.SetActive(true);
    }

    private void PlayPickup()
    {
        print("pickup");
        InGameTransition();
        PickupPlayScreen.SetActive(true);
        ChallengeScreen.SetActive(false);
    }
    
    private void PlayChallenge()
    {
        print("Challenge");
        PickupPlayScreen.SetActive(false);
        ChallengeScreen.SetActive(true);
    }
}
