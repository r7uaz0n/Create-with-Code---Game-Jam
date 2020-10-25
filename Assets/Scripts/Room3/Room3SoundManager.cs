using UnityEngine;

public class Room3SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = default;

    [SerializeField] AudioClip successAudioClip = default;
    [SerializeField] AudioClip failAudioClip = default;
    [SerializeField] AudioClip roomCompleteSound = default;

    public void playSuccessSound()
    {
        audioSource.PlayOneShot(successAudioClip, 1.5f);
    }

    public void playFailSound()
    {
        audioSource.PlayOneShot(failAudioClip, 0.5f);
    }

    public void playRoomCompleteSound()
    {
        audioSource.PlayOneShot(roomCompleteSound, 1.25f);
    }

}
