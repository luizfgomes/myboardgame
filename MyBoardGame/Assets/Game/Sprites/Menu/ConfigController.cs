using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class ConfigController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropDownResulutions;

    private Resolution[] arrayReslutions;

    [SerializeField] private AudioMixer musicMixer,SFXMixer;
    private float musicValue, SFXValue;
    [SerializeField] private Slider sliderMusic, sliderSFX;

    private List<string> resolutions = new List<string>();

    public int currentResolution = 0;
    private void Start() {

        dropDownResulutions.ClearOptions();

        arrayReslutions = Screen.resolutions;

        for(int i =0; i < arrayReslutions.Length; i++) {

            string resolution = arrayReslutions[i].width+"x"+arrayReslutions[i].height;
            resolutions.Add(resolution);

            if (arrayReslutions[i].width == Screen.currentResolution.width &&arrayReslutions[i].height==Screen.currentResolution.height) {
                currentResolution=i;
            }
        }

        dropDownResulutions.AddOptions(resolutions);
        dropDownResulutions.value = currentResolution;
        dropDownResulutions.RefreshShownValue();

        musicValue = PlayerPrefs.GetFloat("musicvolume");
        SFXValue = PlayerPrefs.GetFloat("sfxvolume");

        sliderMusic.value = musicValue;
        sliderSFX.value = SFXValue;

        musicMixer.SetFloat("MusicVolume", musicValue);

        SFXMixer.SetFloat("SFXVolume", SFXValue);
    }

    public void Resolution(int resolutionID) {

        Resolution resolution = arrayReslutions[resolutionID];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void MusicVolume(float volume) {

        musicMixer.SetFloat("musicvolume", volume);
        PlayerPrefs.SetFloat("musicvolume", volume);
    }

    public void SFXVolume(float volume) {

        SFXMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("sfxvolume", volume);
    }

    public void FullScreen(bool isFullScreen) {

        Screen.fullScreen=isFullScreen;
    }

    public void QualityGame(int qualityValue) {

        QualitySettings.SetQualityLevel(qualityValue);
    }
}
