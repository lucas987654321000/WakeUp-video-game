using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LullabyAudio : MonoBehaviour
{
    private AudioSource source;
    public AudioClip lullaby;
    private bool lullabyPlayed = false;
    float lullabyCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lullabyPlayed)
        {
            lullabyCooldown += Time.deltaTime;
            if (lullabyCooldown >= 60f)
            {
                lullabyPlayed = false;
                lullabyCooldown = 0f;
            }
        }
    }

    public void PlayLullaby()
    {
        if (!lullabyPlayed)
        {
            Debug.Log("Playing Lullaby");
            source.PlayOneShot(lullaby);
            lullabyPlayed = true;
        }
    }
}
