using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    public GameObject gameoverUI;
 
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
                Pause();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            menu();
        }
        
        //if (pausemenuUI.active == false)
        //{
        //    Time.timeScale = 1.0f;
        //    GameIsPaused = false;
        //}



    }
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;

    }
    void Pause()
    {
       

        pausemenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;


    }
    public void restartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pausemenuUI.SetActive(false);
        gameoverUI.SetActive(false);
        
        Time.timeScale = 1.0f;
        GameIsPaused = false;

    }
    public void menu()
    {
        pausemenuUI.SetActive(false);
        gameoverUI.SetActive(false);
        GameIsPaused = false;
        
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);


    }
    public void gameover()
    {
        gameoverUI.SetActive(true);
       // inputmenuUI.SetActive(false);
        Time.timeScale = 0.0f;
       


    }
}
