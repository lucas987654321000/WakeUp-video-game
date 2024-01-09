using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    private GameObject collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = this.transform.GetChild(0).gameObject;
        collider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlockDoor()
    {
        collider.SetActive(true);
        try
        {
            GameObject wall = this.transform.GetChild(2).gameObject;
            if (wall.tag == "wall")
            {
                Destroy(wall);
            }
        } catch
        {
            Debug.Log("No wall");
        }
    }
}
