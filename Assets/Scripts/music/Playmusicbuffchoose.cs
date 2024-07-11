using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playmusicbuffchoose : MonoBehaviour
{
    // Start is called before the first frame update
    Music_control control;
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("music").GetComponent<Music_control>();
        control.Playmusic(control.buffchoose);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
