using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public int level;
    public GameObject canvas;
    private GameObject startscreen;
    private GameObject winscreen;
    private GameObject controls;
    private GameObject objective;
    private GameObject pause;
    private GameObject health;
    private GameObject losescreen;
    private GameObject jumpcoff;
    private GameObject attackcoff;
    private GameObject platformcoff;
    private GameObject complete;
    private GameObject complete2;
    private bool paused = true;

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        startscreen = canvas.transform.Find("StartMenu").gameObject;
        winscreen = canvas.transform.Find("Win").gameObject;
        controls = canvas.transform.Find("ControlsScreen").gameObject;
        objective = canvas.transform.Find("ObjectiveScreen").gameObject;
        pause = canvas.transform.Find("Pause").gameObject;
        health = canvas.transform.Find("Health").gameObject;
        losescreen = canvas.transform.Find("Lose").gameObject;
        jumpcoff = canvas.transform.Find("Jump").gameObject;
        attackcoff = canvas.transform.Find("Attack").gameObject;
        platformcoff = canvas.transform.Find("Platforms").gameObject;
        complete = canvas.transform.Find("NextLevel").gameObject;

        //Time.timeScale = 0f;
        if (level == 0)
        {
            Debug.Log("LEVEL 0");
            Time.timeScale = 0f;
        }
        /*else
        {
            Time.timeScale = 1f;
        }*/
    }

    // Update is called once per frame
    void Update()
    {

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

    public void StartGame() {
        // SceneManager.LoadScene("Demo");
        //Debug.Log("STARTING GAME Button Clicked");
        startscreen.SetActive(false);
        Time.timeScale = 1f;
        health.SetActive(true);
    }

    public void RestartGame() {
        if (level == 0) {
            SceneManager.LoadScene("Demo");
        } else if (level == 1) {
            SceneManager.LoadScene("LevelOne");
        } else if (level == 2) {
            SceneManager.LoadScene("LevelTwo");
        }
        Time.timeScale = 1f;
        startscreen.SetActive(false);
    }

    public void RestartEntireGame() {
        SceneManager.LoadScene("Demo");
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void Controls() {
        startscreen.SetActive(false);
        controls.SetActive(true);
    }

    public void ControlsBack() {
        controls.SetActive(false);
        startscreen.SetActive(true);
    }

    public void Objective() {
        startscreen.SetActive(false);
        objective.SetActive(true);
    }

    public void ObjectiveBack() {
        objective.SetActive(false);
        startscreen.SetActive(true);
    }

    public void WinGame()
    {
        startscreen.SetActive(false);
        health.SetActive(false);
        winscreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        startscreen.SetActive(false);
        health.SetActive(false);
        losescreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Okay() {
        jumpcoff.SetActive(false);
        attackcoff.SetActive(false);
        platformcoff.SetActive(false);
        Time.timeScale = 1f;
    }

    public void JumpCoffee() {
        Time.timeScale = 0f;
        jumpcoff.SetActive(true);

    }

    public void AttackCoffee() { 
        Time.timeScale = 0f;
        attackcoff.SetActive(true);
    }

    public void PlatformCoffee() {
        Time.timeScale = 0f;
        platformcoff.SetActive(true);
    }

    public void LevelComplete() {
        Time.timeScale = 0f;
        complete.SetActive(true);
    }

    public void NextLevelOne() {
        SceneManager.LoadScene("LevelOne");
        Time.timeScale = 1f;
    }

    public void NextLevelTwo() {
        SceneManager.LoadScene("LevelTwo");
        Time.timeScale = 1f;
    }
}
