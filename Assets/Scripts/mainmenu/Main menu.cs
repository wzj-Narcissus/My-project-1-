using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public string startname;
    public string backname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(startname);
    }
    public void backgame()
    {
        SceneManager.LoadScene(backname);
    }
    public void quitgame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
        Debug.Log("quitting Game");
    }

}
