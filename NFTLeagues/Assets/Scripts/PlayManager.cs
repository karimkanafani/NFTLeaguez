using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public Button PlayThreeOnThreeButton;
    public GameObject PlayThreeOnThreeScreen;
    private void OnEnable()
    {
        PlayThreeOnThreeButton.onClick.AddListener(Play3on3);
    }

    private void OnDisable()
    {
        PlayThreeOnThreeButton.onClick.RemoveListener(Play3on3);
    }

    private void Play3on3()
    {
        PlayThreeOnThreeScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
