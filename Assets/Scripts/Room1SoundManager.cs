using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Room1SoundManager : MonoBehaviour
{
    public static Room1SoundManager instance;

    public AudioClip CubeChisellingClip;
    public AudioClip PickUpgradeClip;
    public AudioClip StarLiftoffClip;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(PlaySoundAfterDelay());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(2);
    }


    public void PlayCubeChisellingSound()
    {
        audioSource.PlayOneShot(CubeChisellingClip);
    }
    public void PlayPickUpgradeSound()
    {
        audioSource.PlayOneShot(PickUpgradeClip);
    }
    public void PlayStarLiftoffSound()
    {
        audioSource.PlayOneShot(StarLiftoffClip);
    }
}
