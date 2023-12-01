using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;

        PlayBackgroundMusic();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3" || scene.name == "Level1Complete" || scene.name == "Level2Complete" || scene.name == "GameOver")
        {
            PlayBackgroundMusic();
        }
        else
        {
            StopBackgroundMusic();
        }
    }

    private void PlayBackgroundMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopBackgroundMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
