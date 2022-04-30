using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;

    public void OnVolumeChange()
    {
        GameObject.Find("Audio Source").GetComponent<AudioSource>().volume = gameObject.GetComponent<Slider>().value;
    }

    public void OnBackButton()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }
}
