using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioClip[] punchSounds;
    [SerializeField] private Dictionary<string, AudioClip> audioLibrary;

    //Audio Sources
    [SerializeField] private AudioSource deathSource;

    private static SoundManager instance;

    static public SoundManager Instance
    {
        get { return instance; }
    }
    //called when the script instance is being loaded.
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        audioLibrary = new Dictionary<string, AudioClip>(25);

        //Populate Audio Library
        AudioClip[] sounds = Resources.LoadAll<AudioClip>("Sounds");
        for(int i = 0; i < sounds.Length; i++)
        {
            audioLibrary.Add(sounds[i].name, sounds[i]);
            Debug.Log("Sound Loaded: " + sounds[i].name);
        }
        deathSource.clip = audioLibrary["Death"];
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public  AudioClip GetPunch()
    {
        int punchIndex = UnityEngine.Random.Range(0, punchSounds.Length - 1);
        return punchSounds[punchIndex];
    }

    /// <summary>
    /// Play sound method takes in the AudioSource to play the audio from and the key name for the audio clip stored in the sound manager.
    /// The sound name key will be used to index into the dictionary and pull out the sound file 
    /// </summary>
    /// <param name="sourcePlayer"> The Audio Source to play the Sound from</param>
    /// <param name="soundName">Key name that the sound is stored in the audio library under</param>
    public void PlaySound(AudioSource sourcePlayer, string soundName)
    {
        Debug.Assert(audioLibrary.ContainsKey(soundName), "ERROR: AUDIO FILE NOT FOUND IN AUDIO LIBRARY");
        AudioClip sound = audioLibrary[soundName];

        sourcePlayer.clip = sound;
        sourcePlayer.Play();
    }

    /// <summary>
    /// Play sound method takes in the AudioSource to play the audio from and the key name for the audio clip stored in the sound manager.
    /// The sound name key will be used to index into the dictionary and pull out the sound file. Plays sound at volume specified
    /// </summary>
    /// <param name="sourcePlayer">The Audio Source to play the Sound from</param>
    /// <param name="soundName">Key name that the sound is stored in the audio library under</param>
    /// <param name="volume">Volume level to play sound at (Must be between 0 - 1)</param>
    public void PlaySound(AudioSource sourcePlayer, string soundName, float volume)
    {
        Debug.Assert(audioLibrary.ContainsKey(soundName), "ERROR: AUDIO FILE NOT FOUND IN AUDIO LIBRARY");
        Debug.Assert(volume >= 0.0f && volume <= 1.0f, "ERROR: Volume given is not between 0.0f-1.0f");
        AudioClip sound = audioLibrary[soundName];

        sourcePlayer.clip = sound;
        sourcePlayer.volume = volume;
        sourcePlayer.Play();
    }

    /// <summary>
    /// Play sound method takes in the AudioSource to play the audio from and audio clip to play
    /// </summary>
    /// <param name="sourcePlayer"> The Audio Source to play the Sound from</param>
    /// <param name="sound">Sound's Audio Clip</param>
    public void PlaySound(AudioSource sourcePlayer, AudioClip sound)
    {
        sourcePlayer.clip = sound; //Assign audio clip to the audio source player
        sourcePlayer.Play();
    }

    /// <summary>
    /// Play sound method takes in the AudioSource to play the audio from and audio clip to play. Plays audio clip at volume
    /// given. Volume must be between 0-1;
    /// </summary>
    /// <param name="sourcePlayer"> The Audio Source to play the Sound from</param>
    /// <param name="sound">Sound's Audio Clip</param>
    /// <param name="volume">Volume level to play sound at (Must be between 0 - 1)</param>
    public void PlaySound(AudioSource sourcePlayer, AudioClip sound, float volume)
    {
        Debug.Assert(volume >= 0.0f && volume <= 1.0f, "ERROR: Volume given is not between 0.0f-1.0f");

        sourcePlayer.clip = sound;
        sourcePlayer.volume = volume;
        sourcePlayer.Play();
    }

    public void PlayDeath()
    {
        deathSource.Play();
    }

}
