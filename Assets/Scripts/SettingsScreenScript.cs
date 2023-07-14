using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScreenScript : MonoBehaviour
{
    public Button volume;
    public Button haptics;
    public Button home;
    public Sprite onimage;
    public Sprite offimage;
    private bool isMuted = false;
    public static bool isVibrate = true;


    void Start()
    {
        volume.onClick.AddListener(volumebutton);
        haptics.onClick.AddListener(hapticsbutton);
        home.onClick.AddListener(homebutton);

        // Load the values of isMuted and isNotVibrate from PlayerPrefs
        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1;
        isVibrate = PlayerPrefs.GetInt("isVibrate", 0) == 1;

        volume.image.sprite = isMuted ? onimage : offimage;
        haptics.image.sprite = isVibrate ? offimage : onimage;
    }

    void Update()
    {
    }

    public void volumebutton()
    {
        isMuted = !isMuted;
        // AudioListener.pause = isMuted;
        volume.image.sprite = isMuted ? onimage : offimage;

        // Save the value of isMuted to PlayerPrefs
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
    }

    public void hapticsbutton()
    {
        isVibrate = !isVibrate;
        haptics.image.sprite = isVibrate ? offimage : onimage;

        // Save the value of isNotVibrate to PlayerPrefs
        PlayerPrefs.SetInt("isVibrate", isVibrate ? 1 : 0);
    }

    public void homebutton()
    {
        SceneManager.LoadScene("HomeScene 1");
    }
}