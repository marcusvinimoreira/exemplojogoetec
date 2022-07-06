using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControle : MonoBehaviour
{
    public AudioSource musica;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            musica.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            musica.Stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            musica.Pause();
        }
    }
}
