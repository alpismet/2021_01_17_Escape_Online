using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts : MonoBehaviour
{


    public void GameOver()
    {
        SceneManager.LoadScene("Main");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Escape");
    }
}
