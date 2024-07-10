using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flybulletplus : MonoBehaviour
{
    public float Speed = 10;
    public float time1 = 0.8f;
    public float time2 = 10f;
    public float time3 = 40f;
    public float time1_1 = 1f;

    private float beingtime = 0;
    private int y;
    public GameObject fly;
    public Transform minSpawn, maxSpawn;

    public float count = 3;

    private void Start()
    {
        y = 0;
    }

    private void Update()
    {
        beingtime += Time.deltaTime;
        if (beingtime > time2 && beingtime < time3 && y < 10)
        {
            count += Time.deltaTime;
            if (count > time1_1)

            {
                boom();
                count = 0;
                y++;
            }
        }

        if (beingtime > time3)
        {
            count += Time.deltaTime;
            if (count > time1)

            {
                boom();
                count = 0;
            }
        }


    }






    public Vector3 Selectpoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }




        return spawnPoint;
    }








    //private void four(int x)
    //{
    //    switch (x)
    //    {
    //        case 0:
    //            boom(minSpawn);
    //            break;
    //        case 1:
    //            boom1(minSpawn);
    //            break;
    //        case 2:
    //            boom2(maxSpawn);
    //            break;
    //        case 3:
    //            boom3(maxSpawn);
    //            break;

    //        default:
    //            break;
    //    }

    //}

    void boom()
    {
            Vector2 temp = new Vector2();
            Vector3 temp3=Selectpoint();
            temp.x = temp3.x;
            temp.y = temp3.y;
            GameObject bullet = Instantiate(fly, temp, transform.rotation);
            Vector2 newDirection = new Vector2(-temp.x, -temp.y); // 举例设置一个新的飞行方向
            bullet.GetComponent<bullet>().SetDirection(newDirection);
        

    }

    //void boom1(Transform _pos)
    //{
    //    Vector2 temp = new Vector2();
    //    temp.x = _pos.position.x;
    //    temp.y = _pos.position.y;
    //    for (int i = 0; i < vert; i++)
    //    {
    //        GameObject bullet = Instantiate(fly, temp, transform.rotation);
    //        Vector2 newDirection = new Vector2(-temp.x, -temp.y); // 举例设置一个新的飞行方向
    //        bullet.GetComponent<bullet>().SetDirection(newDirection);
    //        temp.y += vert_space;
    //    }

    //}

    //void boom2(Transform _pos)
    //{
    //    Vector2 temp = new Vector2();
    //    temp.x = _pos.position.x;
    //    temp.y = _pos.position.y;
    //    for (int i = 0; i < horiz; i++)
    //    {

    //        GameObject bullet = Instantiate(fly, temp, transform.rotation);
    //        Vector2 newDirection = new Vector2(-temp.x, -temp.y); // 举例设置一个新的飞行方向
    //        bullet.GetComponent<bullet>().SetDirection(newDirection);
    //        temp.x -= horiz_space;
    //    }

    //}

    //void boom3(Transform _pos)
    //{
    //    Vector2 temp = new Vector2();
    //    temp.x = _pos.position.x;
    //    temp.y = _pos.position.y;
    //    for (int i = 0; i < vert; i++)
    //    {

    //        GameObject bullet = Instantiate(fly, temp, transform.rotation);
    //        Vector2 newDirection = new Vector2(-temp.x, -temp.y); // 举例设置一个新的飞行方向
    //        bullet.GetComponent<bullet>().SetDirection(newDirection);
    //        temp.y -= vert_space;
    //    }

    //}
}
