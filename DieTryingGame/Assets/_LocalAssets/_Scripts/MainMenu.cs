using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public OptionsMenu OPTIONS_MENU;
    public void Start()
    {
        OPTIONS_MENU.GetComponent<Animator>().Play("Inactive");
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("TDE_Test"); //loads scene "PlayerTest"
    }
    
    public void QuitGame()
    {
        Debug.Log("The game has been quit.");
        Application.Quit(); //Exits game.
    }
}
