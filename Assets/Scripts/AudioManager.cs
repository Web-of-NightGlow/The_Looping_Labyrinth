using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header ("Audio Clips")]
    public AudioClip musicTRLClip;
    public AudioClip musicDNGClip;
    public AudioClip fireballClip;
    public AudioClip weaponSwingClip;
    public AudioClip relicPickupClip;
    public AudioClip enemyDeathClip;
    public AudioClip playerDeathClip;


    private void Start()
    {
        musicSource.clip = musicTRLClip;
        musicSource.Play();
    }

    
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
   
}

