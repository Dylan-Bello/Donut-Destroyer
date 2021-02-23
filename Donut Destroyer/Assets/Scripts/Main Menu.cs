using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        public void QuitGame()
        {


            Debug.Log("QUIT!");
            Application.quit();
            Endgame();

            public void Endgame()
            {


#if UNITY_EDITOR

          UnityEditor.EditorApplication.isPlaying = false;
#endif


            }



        }
    }
}