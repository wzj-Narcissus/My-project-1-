using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayEnding : MonoBehaviour
{
    PlayerManager playerManager;
    public string nextScene;
    public int flag;
    public GameObject prefab;
    enemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        playerManager= GameObject.Find("Player").GetComponent<PlayerManager>();
        enemySpawner = GameObject.Find("enemy spawner").GetComponent<enemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.FindWithTag("enemy1") == null&& GameObject.FindWithTag("enemy2") == null&& GameObject.FindWithTag("enemy3") == null&&enemySpawner.sign>=4&& GameObject.FindWithTag("Giant") == null)
        {if (flag == 0)
            {
                Instantiate(prefab);
                flag = 1;
            }
            
            //PlayerPrefs.SetFloat("1", playerManager.speed);
            //PlayerPrefs.SetFloat("2", playerManager.damage);
            //PlayerPrefs.SetFloat("3", playerManager.health);
            //PlayerPrefs.SetFloat("4", playerManager.maxHealth);
            //PlayerPrefs.SetFloat("5", playerManager.criticalStrikeRate);
            //PlayerPrefs.SetFloat("6", playerManager.missRate);
            //PlayerPrefs.SetFloat("7", playerManager.shield);
            //PlayerPrefs.SetFloat("8", playerManager.damageMulti);
            //PlayerPrefs.SetFloat("9", playerManager.hurtMulti);
            //SceneManager.LoadScene(nextScene);

        }
        if(GameObject.FindWithTag("enemy1") == null)
        {
            Debug.Log("1");
        }

        if (GameObject.FindWithTag("enemy2") == null)
        {
            Debug.Log("2");
        }
        if (GameObject.FindWithTag("enemy3") == null)
        {
            Debug.Log("3");
        }
        if (GameObject.FindWithTag("Giant") == null)
        {
            Debug.Log("4");
        }

    }
}
