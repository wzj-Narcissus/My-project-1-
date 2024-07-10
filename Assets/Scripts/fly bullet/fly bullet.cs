using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class flybullet : MonoBehaviour
{
    public float Speed = 10;
    public float time1 = 3f;

    private float beingtime = 0;
    private int x;
    private int y;
    public GameObject fly;
    public Transform minSpawn, maxSpawn;
    public int horiz;
    public int vert;
    public int horiz_space;
    public int vert_space;
    private void Start()
    {
        x = Random.Range(0, 4);
        y = 0;
        horiz = 8;
        vert = 5;
        horiz_space = 3;
        vert_space = 3;
    }

    private void Update()
    {
        beingtime += Time.deltaTime;
        if(beingtime > time1&&y==0)

        {
            four(x);
            beingtime = 0;
            x = Random.Range(0, 4);
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
        for (int i = 0; i < horiz; i++)
        {
            
            GameObject bullet = Instantiate(fly, temp, transform.rotation);
            Vector2 newDirection = new Vector2(0, 1); // 举例设置一个新的飞行方向
            bullet.GetComponent<bullet>().SetDirection(newDirection);
            temp.x += horiz_space;
        }

    }

    void boom1(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < vert; i++)
        {
            GameObject bullet = Instantiate(fly, temp, transform.rotation);
            Vector2 newDirection = new Vector2(1,0); // 举例设置一个新的飞行方向
            bullet.GetComponent<bullet>().SetDirection(newDirection);
            temp.y += vert_space;
        }

    }

    void boom2(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < horiz; i++)
        {
            
            GameObject bullet = Instantiate(fly, temp, transform.rotation);
            Vector2 newDirection = new Vector2(0, -1); // 举例设置一个新的飞行方向
            bullet.GetComponent<bullet>().SetDirection(newDirection);
            temp.x -= horiz_space;
        }

    }

    void boom3(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < vert; i++)
        {
      
            GameObject bullet =  Instantiate(fly, temp, transform.rotation);
            Vector2 newDirection = new Vector2(-1, 0); // 举例设置一个新的飞行方向
            bullet.GetComponent<bullet>().SetDirection(newDirection);
            temp.y -= vert_space;
        }

    }


}
