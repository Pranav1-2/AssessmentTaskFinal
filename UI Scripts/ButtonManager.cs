using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //used to operate buttons so that they can be used to open another scene
    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    //used to quit the application
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
