using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class flybullet : MonoBehaviour
{
    public float Speed = 10;
    public float time1 = 4f;
    public float time2=10f;
    public float time3 = 20f;

    private float beingtime = 0;
    private int x;
    private int y;
    public GameObject fly;
    public Transform minSpawn, maxSpawn;
    public int horiz=10;
    public int vert=8;
    public int horiz_space = 5;
    public int vert_space = 5;

    public float count = 3;

    private void Start()
    {
        x = Random.Range(0, 4);
        y = 0;
    }

    private void Update()
    {
        beingtime += Time.deltaTime;
        if(beingtime > time2&&beingtime<time3&&y<2)
        {
            count += Time.deltaTime;
            if (count > time1)

            {
                four(x);
                count = 0;
                x = Random.Range(0, 4);
                y++;
            }
        }

        if (beingtime > time3 ) 
        {
            count += Time.deltaTime;
            if (count > time1)

            {
                four(x);
                count = 0;
                x = Random.Range(0, 4);
            }
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
