using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeUpdate : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider MasterSlider;

    public GameObject BGM_SoundPlayer;
    public GameObject SFX_SoundPlayer;

    AudioSource BGM_Audio;
    AudioSource SFX_Audiio;

    private void Start()
    {
        BGM_Audio = BGM_SoundPlayer.GetComponent<AudioSource>();
        SFX_Audiio = SFX_SoundPlayer.GetComponent<AudioSource>();
    }

    public void SetBgmlVolume()
    {
        BGM_Audio.volume = BGMSlider.value;
    }

    public void SetSfxVolume()
    {
        SFX_Audiio.volume = SFXSlider.value;
    }

    public void SetMasterVolume()
    {
        // m = 0.5  b = 0.3
        if ((MasterSlider.value / 2) * BGMSlider.value < 0)
            BGM_Audio.volume = 0;
        if (SFXSlider.value * MasterSlider.value < 0)
            SFX_Audiio.volume = 0;

        BGM_Audio.volume = BGMSlider.value * (MasterSlider.value / 2);
        SFX_Audiio.volume =  SFXSlider.value *  MasterSlider.value;
    }

}