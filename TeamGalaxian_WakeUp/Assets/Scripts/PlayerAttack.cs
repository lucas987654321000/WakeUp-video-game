using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    public GameObject player;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
        if (c.gameObject.tag == "Enemy"){
            pc.setInRange(true);
            pc.setCurrentEnemy(c.gameObject.transform.parent.gameObject);
        }
    }

        void OnTriggerExit(Collider c){
        if (c.gameObject.tag == "Enemy"){
            pc.setInRange(false);
            pc.setCurrentEnemy(null);
        }
    }
}
