using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class GameSoundManager : MonoBehaviour
{
    public static GameSoundManager instance;
    public AudioClip StarLiftoffClip;

    AudioSource audioSource;
    private void Awake()
    {
       
        int numMusicPlayers = FindObjectsOfType<GameSoundManager>().Length;
        if (numMusicPlayers > 1)
        {
            print("Destroying Game Sound Manager");
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayStarLiftoffSound()
    {
        audioSource.PlayOneShot(StarLiftoffClip);
    }

}
