using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstepsaudio : MonoBehaviour
{
    public AudioSource shootSound;

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)){
            shootSound.enabled = true;
        }
        else
        {
            shootSound.enabled = false;
        }
    }
}
