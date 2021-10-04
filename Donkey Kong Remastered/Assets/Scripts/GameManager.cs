using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float cutSceneTime = 14;
    public GameObject playerPrefab;
    public Transform cutScene;
    public Transform spawnPos;
    public GameObject cam2;
    public GameObject baby;
    public GameObject happy;
    public GameObject drumSpawner;
    public GameObject backgroundMusic;
    public TextMeshProUGUI hearts;
    public GameObject winText;
    public bool paues;
    public GameObject pauesScreen;

    GameObject Player;
    bool spawned;
    bool saved;
    GameObject audioPlayer;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region pause
        if (Input.GetKeyDown(KeyCode.Escape))
            paues = !paues;

        if (paues)
        {
            UnityEngine.Time.timeScale = 0;
            pauesScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        else
        {
            UnityEngine.Time.timeScale = 1;
            pauesScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion
        if (!spawned && cutSceneTime > 0 && Input.anyKey)
            cutSceneTime = 0;

        if (cutSceneTime > 0)
        cutSceneTime -= 1 * Time.deltaTime;

        if (cutSceneTime <= 0 && !spawned)
        {
            spawned = true;
            playerPrefab.GetComponentInChildren<CamLook>().mouseSensitivity = PlayerPrefs.GetFloat("sens");
            playerPrefab.GetComponentInChildren<Camera>().fieldOfView = PlayerPrefs.GetFloat("fov");
            Player = Instantiate(playerPrefab, spawnPos);
            Destroy(cam2);
        }

        if (Player.GetComponent<PlayerController>().Health < 1)
            SceneManager.LoadScene("Level1");

        if (!baby.activeInHierarchy)
        {
            if (!saved)
            {
                audioPlayer = Instantiate(happy);
                saved = true;
                drumSpawner.SetActive(false);
                backgroundMusic.SetActive(false);
                winText.SetActive(true);
            }

            if (!audioPlayer.GetComponent<AudioSource>().isPlaying)
                SceneManager.LoadScene("MainMenu");
        }


        switch (Player.GetComponent<PlayerController>().Health)
        {
            case 3:
                hearts.SetText("Health: |||");
                break;
            case 2:
                hearts.SetText(" Health: ||");
                break;
            case 1:
                hearts.SetText("Health: |");
                break;
            case 0:
                hearts.SetText(":(");
                break;
            default:
                hearts.SetText("Health: ???");
                break;
        }
    }

    public void LoadLevel0()
    {
        paues = false;
        SceneManager.LoadScene("MainMenu");
    }
}
