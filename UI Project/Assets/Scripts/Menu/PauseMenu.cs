using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    public void Resume(){
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    gameIsPaused = false;
}

    public void Pause(){
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    gameIsPaused = true;
}
}

