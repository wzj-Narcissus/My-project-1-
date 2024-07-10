using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class flybullet : MonoBehaviour
{
    public float Speed = 10;
    public float time1 = 3f;

    private float beingtime = 0;

    public GameObject fly;
    public Transform minSpawn, maxSpawn;
    private void Start()
    {
        
    }

    private void Update()
    {
        beingtime += Time.deltaTime;
        if(beingtime > time1)
        {
            
        }

        
    }


    private void four(int x)
    {
        switch (x)
        {
            case 0:
                boom(minSpawn);
                break;
            case 1:
                boom1(minSpawn);
                break;
            case 2:
                boom2(maxSpawn);
                break;
            case 3:
                boom3(maxSpawn);
                break;

            default:
                break;
        }

    }

    void boom(Transform _pos)
    {
        Vector2 temp =new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < 6; i++)
        {
            temp.x += 2;
            Instantiate(fly, temp, transform.rotation);
        }

    }

    void boom1(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < 4; i++)
        {
            temp.y += 2;
            Instantiate(fly, temp, transform.rotation);
        }

    }

    void boom2(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < 6; i++)
        {
            temp.x -= 2;
            Instantiate(fly, temp, transform.rotation);
        }

    }

    void boom3(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < 4; i++)
        {
            temp.y -= 2;
            Instantiate(fly, temp, transform.rotation);
        }

    }


}
