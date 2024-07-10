using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayEnding1 : MonoBehaviour
{
    PlayerManager playerManager;
    public string nextScene;
    public int flag;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindWithTag("enemy1") == null )
        {
            if (flag == 0)
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
    }
}
