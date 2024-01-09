using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCollectable : MonoBehaviour
{

    private Animator anim;
    private bool isStopping = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (anim != null)
        {
            CoffeeCollector cc = c.attachedRigidbody.gameObject.GetComponent<CoffeeCollector>();
            if (cc != null)
            {
                anim.SetFloat("endSpin", 0f);
                anim.SetFloat("spin", 1f);
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (anim != null)
        {
            CoffeeCollector cc = c.attachedRigidbody.gameObject.GetComponent<CoffeeCollector>();
            if (cc != null)
            {
                anim.SetFloat("endSpin", 1f);
                anim.SetFloat("spin", 0f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
