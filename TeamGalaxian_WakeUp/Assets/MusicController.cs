using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource source;
    public AudioClip music;
    private bool musicPlayed = false;
    float lullabyCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = music;
        source.loop = true;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
