using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathTrigger : MonoBehaviour
{
    public GameObject[] skeletons;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach(var s in skeletons)
        {
            if (s != null)
            {
                count++;
            }
        }
        if (count == 0)
        {
            door.GetComponent<DoorUnlock>().unlockDoor();
        }
    }
}
