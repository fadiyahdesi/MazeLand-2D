using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void paused()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }
}
