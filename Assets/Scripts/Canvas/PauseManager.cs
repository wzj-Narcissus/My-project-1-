using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public string mainMenu;
    public string startScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Resume();
        //}
    }
    public void Resume()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }
    public void New_Start()
    {
        SceneManager.LoadScene(startScene);
        Time.timeScale = 1;
    }
    public void Return()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }
}
