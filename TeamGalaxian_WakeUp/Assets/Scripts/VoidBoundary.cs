using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private Vector3 checkpoint = new Vector3(0, 6.5f, 0);

    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody.gameObject == player)
        {
            Rigidbody collidingObject = c.attachedRigidbody.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Checkpoint Activated: " + checkpoint);
            collidingObject.transform.position = checkpoint;
            // Animator anim = player.GetComponent<Animator>();
            // bool isFalling = anim.GetBool("isFalling");
            // anim.SetBool("isFalling", false);
        }
    }

    public void SetCheckpoint(float x, float y, float z)
    {
        checkpoint = new Vector3(x, y, z);
        Debug.Log("Checkpoint Set: " + checkpoint);
    }
}
