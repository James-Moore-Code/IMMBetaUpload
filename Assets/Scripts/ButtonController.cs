using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{ 
    private string url = "https://github.com/James-Moore-Code/IMMBetaUpload";
    public void PlayGame()
    {
        SceneManager.LoadScene("MyGame");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LinkToGithub()
    {
        Application.OpenURL(url);
    }
}
