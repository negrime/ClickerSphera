using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;

    public Text bestScoreTxt;

    [Header("Timer")] 
    public Slider timerSlider;

    public Text timerTxt;

    [Header("Sound")] 
    public Toggle toggleSound;

    private int _isOn;
    private void Awake()
    {
        _isOn = PlayerPrefs.GetInt("Sound");
        if (PlayerPrefs.GetInt("GameTime") == 0)
        {
            timerTxt.text = timerSlider.minValue.ToString();
            timerSlider.value = timerSlider.minValue;
        }
        else
        {
            timerTxt.text = (PlayerPrefs.GetInt("GameTime")).ToString() + " SEC.";
            timerSlider.value = (PlayerPrefs.GetInt("GameTime"));
        }

        if (_isOn > 0)
            toggleSound.isOn = true;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("BestScore") != 0)
        {
            bestScoreTxt.gameObject.SetActive(true);
            bestScoreTxt.text = "BEST SCORE : " + PlayerPrefs.GetInt("BestScore").ToString();
        }
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Game");   
    }

    public void OnSettingsClick()
    {
        mainPanel.SetActive(!mainPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);

    }

    public void OnBackToMenuClick()
    {
        mainPanel.SetActive(!mainPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        SaveSettings();
    }

    public void OnTimerChanged()
    {
        timerTxt.text = timerSlider.value.ToString() + " SEC.";
    }

    public void OnSoundChanged()
    {
        _isOn = toggleSound.isOn ? 1 : 0;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("GameTime", (int)timerSlider.value);
        PlayerPrefs.SetInt("Sound", _isOn);
    }

    public void OnExitClick()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
