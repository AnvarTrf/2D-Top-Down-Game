using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip background;

    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    private void Start(){
        musicSource.clip=background;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
