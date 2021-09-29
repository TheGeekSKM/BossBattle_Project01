using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioPlayerManager : MonoBehaviour
{
    [SerializeField] AudioClip _soundEffect;

    public void PlayMusic()
    {
        AudioHelper.PlayClip2D(_soundEffect, 1f);
    }
}
