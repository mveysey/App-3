using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


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
}
