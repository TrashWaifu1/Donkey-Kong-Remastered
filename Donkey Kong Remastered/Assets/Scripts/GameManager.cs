using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;


    void Start()
    {
        
    }

    void Update()
    {
        if (Player.GetComponent<PlayerController>().Health < 1)
            SceneManager.LoadScene(0);
    }
}
