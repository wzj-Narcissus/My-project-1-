using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enenmySp5 : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject testenemy;

    public float timetospawn;
    public Transform minSpawn, maxSpawn;
    public int sign;
    public float counttime;

     // Start is called before the first frame update
    void Start()
    {
        sign = 1;
        counttime = 0;

    }

    // Update is called once per frame
    void Update()
    {


            counttime += Time.deltaTime;
            if (counttime > timetospawn)
            {

            if (sign > 3)
            {
                sign %= 3;
            }
                        switch (sign)
                        {
                            case 1:
                                Instantiate(enemy1, Selectpoint(), transform.rotation);
                                break;
                            case 2:
                                Instantiate(enemy2, Selectpoint(), transform.rotation);
                                break;
                            case 3:
                                Instantiate(enemy3, Selectpoint(), transform.rotation);
                                break;
                            default:
                                break;
                        }

                        sign++;

                  counttime = 0;
            }
        }
    
    public Vector3 Selectpoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y=Random.Range(minSpawn.position.y, maxSpawn.position.y);

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



}
