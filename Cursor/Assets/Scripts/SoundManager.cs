using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource src;

    public AudioClip impact;
    public AudioClip gun;
    public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        src.clip = click;
        src.Play();
    }

    public void PlayImpact()
    {
        src.clip = impact;
        src.Play();
    }

    public void Gunshot()
    {
        src.clip = gun;
        src.Play();
    }
}
