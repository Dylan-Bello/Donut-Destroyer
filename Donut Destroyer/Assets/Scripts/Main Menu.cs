using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void QuitGame()
    {


        Debug.Log("QUIT!");
        Application.Quit();
        Endgame();
    }
    void Endgame()
    {

        #if UNITY_EDITOR

          UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }



       
}
