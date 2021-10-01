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

    GameObject Player;
    bool spawned;
    bool saved;
    GameObject audioPlayer;

    void Update()
    {
        if (!spawned && cutSceneTime > 0 && Input.anyKey)
            cutSceneTime = 0;

        if (cutSceneTime > 0)
        cutSceneTime -= 1 * Time.deltaTime;

        if (cutSceneTime <= 0 && !spawned)
        {
            spawned = true;
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
                hearts.SetText("Health: ###");
                break;
            case 2:
                hearts.SetText(" Health: ##");
                break;
            case 1:
                hearts.SetText("Health: #");
                break;
            case 0:
                hearts.SetText(":(");
                break;
            default:
                hearts.SetText("Health: ???");
                break;
        }
    }
}
