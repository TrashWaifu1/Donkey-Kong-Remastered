using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float cutSceneTime = 14;
    public GameObject playerPrefab;
    public Transform cutScene;
    public Transform spawnPos;
    public GameObject cam2;

    GameObject Player;
    bool spawned;

    void Update()
    {
        if (cutSceneTime > 0)
        cutSceneTime -= 1 * Time.deltaTime;

        if (cutSceneTime <= 0 && !spawned)
        {
            spawned = true;
            Player = Instantiate(playerPrefab, spawnPos);
            //cam2.SetActive(false);
            Destroy(cam2);
        }

        if (Player.GetComponent<PlayerController>().Health < 1)
            SceneManager.LoadScene(0);
    }
}
