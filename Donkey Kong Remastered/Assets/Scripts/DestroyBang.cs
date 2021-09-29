using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBang : MonoBehaviour
{
    public AudioSource player;

    void Update()
    {
        if (!player.isPlaying)
            Destroy(gameObject);
    }
}
