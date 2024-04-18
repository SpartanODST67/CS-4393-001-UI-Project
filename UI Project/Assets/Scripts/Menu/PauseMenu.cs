using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] GameObject inputHander;
    [SerializeField] GameObject dialogueRunner;
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
        inputHander.SetActive(true);
        dialogueRunner.SetActive(true);
        gameIsPaused = false;
}

    public void Pause(){
    pauseMenuUI.SetActive(true);
        inputHander.SetActive(false);
        dialogueRunner.SetActive(false);
        gameIsPaused = true;
}
}

