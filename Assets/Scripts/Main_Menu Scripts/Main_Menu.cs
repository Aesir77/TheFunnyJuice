using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] private string Start;
    public void play()
    {
      
        SceneManager.LoadScene(Start);
    }

    public void quit()
    {
        Application.Quit();
    }
   
}
