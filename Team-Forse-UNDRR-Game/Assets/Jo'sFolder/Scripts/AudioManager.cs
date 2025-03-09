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
    public AudioClip WarningSFX;
    public AudioClip iPadSelectSFX;

    //
    private AudioSource BGMAudioSource;
    private AudioSource clickSFXAudioSource;

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
        clickSFXAudioSource = GetComponent<AudioSource>();
        if (Input.GetMouseButtonDown(0))
        {
            clickSFXAudioSource.Play();
        }
    }
}
