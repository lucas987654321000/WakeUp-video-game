using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    private AudioSource source;
    public AudioClip open;
    public AudioClip close;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c) {
        if (c.attachedRigidbody != null) {
            DoorOpener od = c.attachedRigidbody.gameObject.GetComponent<DoorOpener>(); 
            if (od != null) {
                Debug.Log("enter");
                door.GetComponent<Animator>().Play("Door Open", 0, 0);
                source.PlayOneShot(open);
                od.OpenedDoor();
            }
        }
    }

    void OnTriggerExit(Collider c) {
         if (c.attachedRigidbody != null) {
            DoorOpener od = c.attachedRigidbody.gameObject.GetComponent<DoorOpener>(); 
            if (od != null) {
                Debug.Log("exit");
                door.GetComponent<Animator>().Play("Door Close", 0, 0);
                source.PlayOneShot(close);
            }
        }
    }


}
