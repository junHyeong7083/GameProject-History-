using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeUpdate : MonoBehaviour
{
    [Header("Slider")]
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider MasterSlider;

    [Header("SoundPlayer")]
    public GameObject BGM_SoundPlayer;
    public GameObject SFX_SoundPlayer;

    AudioSource BGM_Audio;
    AudioSource SFX_Audiio;

    private void Start()
    {
        BGM_Audio = BGM_SoundPlayer.GetComponent<AudioSource>();
        SFX_Audiio = SFX_SoundPlayer.GetComponent<AudioSource>();

        LoadVolume(); // ������ ������ ���� �� �ε�
    }

    public void SetBgmlVolume()
    {
        BGM_Audio.volume = BGMSlider.value * MasterSlider.value;
        SaveVolume(); // ���� �� ����
    }

    public void SetSfxVolume()
    {
        SFX_Audiio.volume = SFXSlider.value * MasterSlider.value;
        SaveVolume(); // ���� �� ����
    }

    public void SetMasterVolume()
    {
        SaveVolume(); // ���� �� ����
    }
    public void UpMater()
    {
        MasterSlider.value += 0.2f;
        SaveVolume(); // ���� �� ����
    }

    public void DownMater()
    {
        MasterSlider.value -= 0.2f;
        SaveVolume(); // ���� �� ����
    }

    public void UpBgm()
    {
        BGMSlider.value += 0.1f;
        SaveVolume(); // ���� �� ����
    }

    public void DownBgm()
    {
        BGMSlider.value -= 0.1f;
        SaveVolume(); // ���� �� ����
    }

    public void UpSfx()
    {
        SFXSlider.value += 0.2f;
        SaveVolume(); // ���� �� ����
    }

    public void DownSfx()
    {
        SFXSlider.value -= 0.2f;
        SaveVolume(); // ���� �� ����
    }
    private void LoadVolume()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        MasterSlider.value = masterVolume;
        BGMSlider.value = bgmVolume;
        SFXSlider.value = sfxVolume;

        BGM_Audio.volume = bgmVolume * masterVolume;
        SFX_Audiio.volume = sfxVolume * masterVolume;
    }

    private void SaveVolume()
    {
        float masterVolume = MasterSlider.value;
        float bgmVolume = BGMSlider.value;
        float sfxVolume = SFXSlider.value;

        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}
