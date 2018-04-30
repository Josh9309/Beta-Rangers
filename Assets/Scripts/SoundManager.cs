using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager> {
    [SerializeField] private AudioClip[] punchSounds;
    [SerializeField] private AudioClip jump;
    [SerializeField] public AudioClip death;

    //Audio Sources
    [SerializeField] private AudioSource deathSource;

    //called when the script instance is being loaded.
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        deathSource.clip = death;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public  AudioClip GetPunch()
    {
        int punchIndex = UnityEngine.Random.Range(0, punchSounds.Length - 1);
        return punchSounds[punchIndex];
    }

    public  AudioClip GetJump()
    {
        return jump;
    }

    public void PlayDeath()
    {
        deathSource.Play();
    }
}
