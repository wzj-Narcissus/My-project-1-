using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;
    public float beingtime=0;
    public float time1 = 5;
    public float time2 = 10;
    public int movekind;
    // Start is called before the first frame update
    void Start()
    {
        beingtime = 0;
        movekind = 1;
    }

    // Update is called once per frame
    void Update()
    {
        beingtime += Time.deltaTime;
        if (beingtime > time1) 
        {

            if (movekind > 3)
            {
                movekind %= 3;
            } 
            movement(movekind);
            movekind++;


            beingtime = 0;
        }


    }


    public void movement(int x)
    {
        switch (x)
        {
            case 1:
                lefthand.SetActive(true);
                righthand.SetActive(false);
                break;
            case 2:
                lefthand.SetActive(false);
                righthand.SetActive(true);
                break;
            case 3:
                lefthand.SetActive(false);
                righthand.SetActive(false);
                break;


            default:
                break;
        }

    }

}
