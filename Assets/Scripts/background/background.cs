using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class background : MonoBehaviour
{
    public string nextname;
    Music_control control;
    // Start is called before the first frame update
    void Start()
    {
        control =GameObject.FindGameObjectWithTag("music").GetComponent<Music_control>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenbutton()
    {
        control.Playmusic(control.click);
        SceneManager.LoadScene(nextname);

    }
}
