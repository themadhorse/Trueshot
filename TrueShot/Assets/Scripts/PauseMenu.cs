using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject player;

    

    private void Start()
    {
        PauseMenuUI.SetActive(false);
        
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
	}

   public void Resume()
    {
        PauseMenuUI.SetActive(false);   
        Time.timeScale = 1f;
        GameIsPaused = false;
        player.GetComponent<Shoot>().setCanShoot(true);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        player.GetComponent<Shoot>().setCanShoot(false);
    }

    
}
