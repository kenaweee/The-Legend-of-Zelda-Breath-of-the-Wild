using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    bool ismuted = false;
    int x = 5;
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void Mute()
    {
        if (ismuted == false)
        {
            AudioListener.volume = 0;
            ismuted = true;
        }
        else
        {
            AudioListener.volume = 1;
            ismuted = false;
        }
    }


}
