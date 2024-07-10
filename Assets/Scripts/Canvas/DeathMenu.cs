using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string startScene;
    public string mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewStart()
    {
        PlayerPrefs.DeleteAll();

        Time.timeScale = 1;
        SceneManager.LoadScene(startScene);
      
    }
    public void Return()
    {
        PlayerPrefs.DeleteAll();

        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }
}
