using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject final_page;


    void Start()
    {
        Time.timeScale = 0;
        score.points = 0;
        
    }
    public void play() 
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void replay()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
