using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManagerr : DinoBehaviourScript
{
    protected static AudioManagerr instance;
    public static AudioManagerr Instance => instance;
    [SerializeField] protected Sound[] musicSound, sfxSound;
    [SerializeField] protected AudioSource musicSource, sfxSource, footStepSource;
    public AudioSource FootStepSource => footStepSource;
    public AudioSource SfxSource => sfxSource;
    protected override void Start()
    {
        base.Start();
        this.ClockMusic();
    }
    protected override void Awake()
    {
        base.Awake();
        if (AudioManagerr.instance != null) Debug.LogWarning("Only 1 AudioManagerr allow to exist");
        AudioManagerr.instance = this;
    }
    public void ClockMusic()
    {
        this.musicSource.gameObject.SetActive(false);
    }
    public void OpenMusic()
    {
        this.musicSource.gameObject.SetActive(true);
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, sound => sound.soundName.ToString() == name);
        if (s == null) return;
        this.musicSource.clip = s.clip;
        this.musicSource.Play();
    }
    public void PlayMusic(string name, float volume)
    {
        Sound s = Array.Find(musicSound, sound => sound.soundName.ToString() == name);
        if (s == null) return;
        this.musicSource.clip = s.clip;
        this.musicSource.volume = volume;
        this.musicSource.Play();
    }
    public void StopMusic()
    {
        this.musicSource.Stop();
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, sound => sound.soundName.ToString() == name);
        if (s == null) return;
        this.sfxSource.PlayOneShot(s.clip);
    }
    public void PlaySFX(string name, float volume)
    {
        Sound s = Array.Find(sfxSound, sound => sound.soundName.ToString() == name);
        if (s == null) return;
        this.sfxSource.PlayOneShot(s.clip, volume);
    }
}
