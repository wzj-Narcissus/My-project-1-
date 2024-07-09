using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject preFab;
    //int c = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GameObject p = Instantiate(preFab);
            p.SetActive(true);
        }
    }
    public void Pause_Menu()
    {
        //if (c == 0)
        //{
        //    preFab.SetActive(true);
        //    Time.timeScale = 0;
        //    c = 1;
        //}
        //else
            Time.timeScale = 0;
            GameObject p=Instantiate(preFab);
            p.SetActive(true);
        

    }
}
