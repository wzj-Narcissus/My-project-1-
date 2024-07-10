using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject testenemy;

    public float timetospawn;
    private float spawnCounter;
    public Transform minSpawn, maxSpawn;
    public int sign;
    public float counttime;
    public float counttime1;
    public float counttime2;
    public int key;
     // Start is called before the first frame update
    void Start()
    {
        sign = 1;
        key = 0;
        spawnCounter = timetospawn;
        counttime = 13;
        counttime1 = 0;
        counttime2 = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (sign <= 3)
        {

            if (GameObject.FindWithTag("enemy1") == null && sign == 1&&key==1)
            {
                counttime = 14.8f;
                counttime1 = 0;
                spawnCounter = timetospawn;
                sign += 1;
            }

            if (GameObject.FindWithTag("enemy2") == null && sign == 2&&key==2)
            {
                counttime = 14.8f;
                counttime1 = 0;
                spawnCounter = timetospawn;
                sign += 1;
            }

            counttime += Time.deltaTime;
            if (counttime > 15)
            {

                counttime1 += Time.deltaTime;
                
                if (counttime1 < 2)
                {
                    spawnCounter -= Time.deltaTime;

                    if (spawnCounter < 0)
                    {
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
                        spawnCounter = timetospawn;
                        key++;
                    }

                }
                else
                {
                    counttime = 2;
                    counttime1 = 0;
                    spawnCounter = timetospawn;
                    sign++;
                }

            }
            else
            {

            }
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
