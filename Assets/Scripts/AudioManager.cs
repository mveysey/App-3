using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip falling;
    public AudioClip checkpoint;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip attack;
    public AudioClip hit;

   /* private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }*/
    // Start is called before the first frame update
    private void Start()
    {
       musicSource.clip = background;
       musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
