using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //loads scene "PlayerTest"
    }
    
    public void QuitGame()
    {
        Debug.Log("The game has been quit.");
        Application.Quit(); //Exits game.
    }
}
