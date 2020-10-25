using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Room1SoundManager : MonoBehaviour
{
    public static Room1SoundManager instance;

    public AudioClip RocksFallingClip;
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
        if (!GameState.checkKeyCollectionStatus(GameState.KeyId.Room1))
        {
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(PlaySoundAfterDelay());
        }
    }
        IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(RocksFallingClip);
    }

        public void PlayCubeChisellingSound()
    {
        audioSource.PlayOneShot(CubeChisellingClip,0.1f);
    }
    public void PlayPickUpgradeSound()
    {
        audioSource.PlayOneShot(PickUpgradeClip,0.05f);
    }
    //public void PlayStarLiftoffSound()
    //{
    //    audioSource.PlayOneShot(StarLiftoffClip);
    //}
}
