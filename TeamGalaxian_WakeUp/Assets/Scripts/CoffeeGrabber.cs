using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeGrabber : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dreamPlane;

    void Start()
    {
        
    }


    void OnTriggerEnter(Collider c)
    {
        CoffeeCollector cc = c.attachedRigidbody.gameObject.GetComponent<CoffeeCollector>();
        if (cc != null)
        {
            //PlayerController pc = c.attachedRigidbody.gameObject.GetComponent<PlayerController>();
            PlayerController pc = c.attachedRigidbody.gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
            Debug.Log(c.GetComponent<CapsuleCollider>().height);
            if (pc != null)
            {
                //Destroy(gameObject);
                pc.coffeeCollected();
                if (dreamPlane != null)
                {
                    Vector3 pos = this.transform.position;
                    Debug.Log("Setting Checkpoint: " + pos);
                    dreamPlane.GetComponent<BoundaryController>().SetCheckpoint(pos.x, pos.y + 1, pos.z);
                }
                Destroy(gameObject);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
