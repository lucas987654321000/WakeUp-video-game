using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 checkpoint = new Vector3(0, 6.5f, 0);

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag == "Player")
        {
            c.collider.gameObject.transform.position = checkpoint;
            c.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log(c.collider.attachedRigidbody.velocity.ToString());
        }
    }

    public void SetCheckpoint(float x, float y, float z)
    {
        checkpoint = new Vector3(x, y, z);
        Debug.Log("Checkpoint Set: " + checkpoint);
    }
}
