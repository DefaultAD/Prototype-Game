using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource primaryAudioSource;
    public AudioSource secondaryAudioSource;

    public AudioClip flippingAudioClip;
    public AudioClip matchAudioClip;
    public AudioClip mismatchAudioClip;
    public AudioClip gameOverAudioClip;

    public void FlipCardAudio()
    {
        primaryAudioSource.clip = flippingAudioClip;
        primaryAudioSource.Play();
    }

    public void MatchCardsAudio()
    {
        secondaryAudioSource.clip = matchAudioClip;
        secondaryAudioSource.Play();
    }

    public void MismatchCardsAudio()
    {
        secondaryAudioSource.clip = mismatchAudioClip;
        secondaryAudioSource.Play();
    }

    public void GameOverAudio()
    {
        primaryAudioSource.clip = gameOverAudioClip;
        primaryAudioSource.Play();
    }
}
