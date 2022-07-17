using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip diceRoll;

    [Header("Player")]
    [SerializeField] public AudioClip playerAtk;
    [SerializeField] public AudioClip playerDead;

    [Header("Enemy")]
    [SerializeField] public AudioClip enemyAtk;
    [SerializeField] public AudioClip enemyDead;

    [SerializeField] public AudioClip clickSFX;
    [SerializeField] AudioSource sfxSource;
    void Awake()
    {
        int numAudioManager = FindObjectsOfType<AudioManager>().Length;
        if (numAudioManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DiceAudio() 
    {
        sfxSource.PlayOneShot(diceRoll, 1f);
    }

    public void PAtkAudio() 
    {
        sfxSource.PlayOneShot(playerAtk, 1f);
    }

    public void PDeadAudio() 
    {
        sfxSource.PlayOneShot(playerDead, 1f);
    }

    public void EAtkAudio() 
    {
        sfxSource.PlayOneShot(enemyAtk, 1f);
    }

    public void EDeadAudio() 
    {
        sfxSource.PlayOneShot(enemyDead, 1f);
    }

    public void ClickAudio() 
    {
        sfxSource.PlayOneShot(clickSFX, 1f);
    }

    public void SetEAudios(AudioClip eAtk, AudioClip eDead)
    {
        enemyDead = eDead;
        enemyAtk = eAtk;
    }
}
