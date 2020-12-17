using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{ 
    public string url = "https://vle-bn.tudublin.ie/login/index.php";
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
