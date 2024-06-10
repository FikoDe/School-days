using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private  AudioClip basicMusick;
    [SerializeField] private AudioClip combatMusic;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = basicMusick;
        audioSource.Play();
    }

    //method which turns on combat music
    public void musicInCombat()
    {
        if (!audioSource.isPlaying || audioSource.clip != combatMusic)
        {
            audioSource.clip = combatMusic;
            audioSource.Play();
        }

    }

    //method which turns on basic music
    public void basicMusic()
    {
        if (!audioSource.isPlaying || audioSource.clip != basicMusick)
        {
            audioSource.clip = basicMusick;
            audioSource.Play();
        }

    }

    //method for turning down the volume
    public void volumeDownd()
    {
        audioSource.volume = 0;
    }

    //method for turning up the volume;
    public void volumeUp()
    {
        audioSource.volume = 0.1f;
    }


}
