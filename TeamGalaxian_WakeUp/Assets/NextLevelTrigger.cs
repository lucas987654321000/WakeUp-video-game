using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private UIHandler uiHandler;
    // Start is called before the first frame update
    void Start()
    {
         uiHandler = GetComponent<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {

            uiHandler.LevelComplete();
        }
    }
}
