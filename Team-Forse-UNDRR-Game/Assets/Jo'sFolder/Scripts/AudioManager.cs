using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //
    public static AudioManager Instance;

    //
    public AudioClip backgroundMusic;
    public AudioClip clickSFX;

    //
    private AudioSource BGMAudioSource, clickSFXAudioSource;

    private void Awake()
    {
        //don't destroy on load + Static Instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        BGMAudioSource = GetComponent<AudioSource>();
        BGMAudioSource.loop = true;
        BGMAudioSource.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlayClick();
        }
    }

    private void PlayClick()
    {
        clickSFXAudioSource.PlayOneShot(clickSFX);
    }
}
