using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public void playGame()
   {
        SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
        Debug.Log("Quit!");
        Application.Quit();
   }

}
