using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject mainMenu;
    public Slider fovSlider;
    public TextMeshProUGUI fovNum; 
    public Slider sensSlider;
    public TextMeshProUGUI sensNum;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        fovNum.SetText(fovSlider.value.ToString());
        sensNum.SetText(sensSlider.value.ToString());
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);

        if (PlayerPrefs.GetFloat("fov") != 0)
            fovSlider.value = PlayerPrefs.GetFloat("fov");

        if (PlayerPrefs.GetFloat("sens") != 0)
            sensSlider.value = PlayerPrefs.GetFloat("sens");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);

        PlayerPrefs.SetFloat("fov", fovSlider.value);
        PlayerPrefs.SetFloat("sens", sensSlider.value);
    }
}
