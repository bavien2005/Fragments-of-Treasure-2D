using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameObject optionMenu;

    [SerializeField] private GameObject obj;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [SerializeField] private TextMeshProUGUI textMusicVolume;
    [SerializeField] private TextMeshProUGUI textSoundVolume;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            float musicValue = AudioManager.instance.GetMusicVolume();
            float soundValue = AudioManager.instance.GetSoundVolume();

            musicSlider.value = musicValue;
            soundSlider.value = soundValue;

            textMusicVolume.text = Mathf.RoundToInt(musicValue * 100) + "%";
            textSoundVolume.text = Mathf.RoundToInt(soundValue * 100) + "%";
        }
    }
    public void SetActiveMainMenu(bool check)
    {
        if (mainMenu != null)
        {
            mainMenu.SetActive(check);
        }
    }

    public void SetActiveOptionMenu(bool check)
    {
        if (optionMenu != null)
        {
            optionMenu.SetActive(check);
        }
    }

    public void OnMusicSliderChanged(float value)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ChangeMusicVolume(value);
            textMusicVolume.text = ((int)(value * 100)).ToString() + "%";
        }
    }

    public void OnSoundSliderChanged(float value)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ChangeSoundVolume(value);
            textSoundVolume.text = ((int)(value * 100)).ToString() + "%";
        }
    }

    public void SetActiveObj(bool check)
    {
        if (obj != null)
        {
            obj.SetActive(check);
        }
    }
    

}
