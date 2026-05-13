using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioSource effectAudio;

    [SerializeField] private AudioClip clickBtn;

    [SerializeField] private AudioClip backSound;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SOUND_VOLUME_KEY = "SoundVolume";
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Start()
    {
       backgroundAudio.clip = backSound;
       backgroundAudio.Play();
        LoadVolume();
    }

    public void PlaySoundClickBtn()
    {
        if (effectAudio != null)
        {
            effectAudio.PlayOneShot(clickBtn);
        }
    }

    public void ChangeMusicVolume(float value)
    {
        if (backgroundAudio != null)
        {
            backgroundAudio.volume = value;
        }
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
        PlayerPrefs.Save();
    }

    public void ChangeSoundVolume(float value)
    {
        if (effectAudio != null)
        {
            effectAudio.volume = value;
        }
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, value);
        PlayerPrefs.Save();
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY , 0.5f);
    }
    public float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(SOUND_VOLUME_KEY, 0.5f);
    }

    public void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.5f);
        float soundVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.5f);

        if (backgroundAudio != null)
        {
            backgroundAudio.volume = musicVolume;
        }

        if (effectAudio != null)
        {
            effectAudio.volume = soundVolume;
        }
    }
}
