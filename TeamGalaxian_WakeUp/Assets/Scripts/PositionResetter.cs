using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    private Vector3 resetPos;
    // Start is called before the first frame update
    void Start()
    {
        resetPos = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.transform.localPosition != resetPos)
        {
            this.transform.localPosition = resetPos;
        }
    }
}
