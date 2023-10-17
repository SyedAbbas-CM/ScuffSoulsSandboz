using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioSource source;

    [SerializeField]
    private AudioClip scream, die;
    [SerializeField]
    private AudioClip[] attack;


    private void Awake()
    {
        source = GetComponent<AudioSource>();   
    }

    public void Play_screamSound()
    {
        source.clip = scream;
        source.Play();
    }
    public void Play_attackSound()
    {
        source.clip = attack[Random.Range(0,attack.Length)];
        source.Play();
    }
    public void Play_deathSound()
    {
        source.clip = die;
        source.Play();
    }

}
