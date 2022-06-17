using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void AppStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("exited");
    }
}
