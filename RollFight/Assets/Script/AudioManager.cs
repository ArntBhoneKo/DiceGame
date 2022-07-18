using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip diceRoll;

    [Header("Player")]
    public AudioClip playerAtk;
    public AudioClip playerDead;
    public AudioClip playerOtherAction;

    [Header("Enemy")]
    public AudioClip enemyAtk;
    public AudioClip enemyDead;

    public AudioClip clickSFX;
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
        int actionNum = FindObjectOfType<GameManager>().action;
        if (actionNum == 0)
        {
            sfxSource.PlayOneShot(playerAtk, 1f);
        }
        else if (actionNum == 1)
        {
            sfxSource.PlayOneShot(playerOtherAction, 1f);
        }
        else if (actionNum == 2)
        {
            sfxSource.PlayOneShot(playerOtherAction, 1f);
        }
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
