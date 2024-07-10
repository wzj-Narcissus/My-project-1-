using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("enemy1") == null&& GameObject.FindWithTag("enemy2") == null&& GameObject.FindWithTag("enemy3") == null)
        {

        }
    }
}
