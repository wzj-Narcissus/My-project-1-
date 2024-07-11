using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changescene : MonoBehaviour
{
    // Start is called before the first frame update
    public string firstscene;
    public string nextscene;
    public string prescene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void whenbutton1()
    {
        SceneManager.LoadScene(firstscene);
    }
    public void whenbutton2() 
    {
        SceneManager.LoadScene(nextscene);
    }
    public void whenbutton3()
    {
        SceneManager.LoadScene(prescene);
    }
}
