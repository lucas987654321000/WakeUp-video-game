using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject pause; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("p")) {
            Debug.Log("pressed");
            paused = !paused;
            PauseGame();
         } 
    }

        void PauseGame() {
        if (paused) {
            Time.timeScale = 0f;
            pause.SetActive(true);

        } else {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }
}
