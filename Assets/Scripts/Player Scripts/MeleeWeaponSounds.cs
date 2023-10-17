using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] sounds;

    void PlaySounds()
    {
        audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        audioSource.Play();
    }
}
