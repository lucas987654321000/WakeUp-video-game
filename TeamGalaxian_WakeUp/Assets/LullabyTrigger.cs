using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LullabyTrigger : MonoBehaviour
{
    public GameObject environment;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Collided");
        if (c.gameObject.tag == "Player")
        {
            LullabyAudio lullaby = environment.GetComponent<LullabyAudio>();
            if (lullaby == null)
            {
                Debug.Log("Null lullaby");
            } else
            {
                Debug.Log("lullaby found");
            }
            lullaby.PlayLullaby();
        }
    } 
}
