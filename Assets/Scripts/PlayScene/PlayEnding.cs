using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayEnding : MonoBehaviour
{
    PlayerManager playerManager;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        playerManager= GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("enemy1") == null&& GameObject.FindWithTag("enemy2") == null&& GameObject.FindWithTag("enemy3") == null)
        {
            PlayerPrefs.SetFloat("1", playerManager.speed);
            PlayerPrefs.SetFloat("2", playerManager.damage);
            PlayerPrefs.SetFloat("3", playerManager.health);
            PlayerPrefs.SetFloat("4", playerManager.maxHealth);
            PlayerPrefs.SetFloat("5", playerManager.criticalStrikeRate);
            PlayerPrefs.SetFloat("6", playerManager.missRate);
            PlayerPrefs.SetFloat("7", playerManager.shield);
            PlayerPrefs.SetFloat("8", playerManager.damageMulti);
            PlayerPrefs.SetFloat("9", playerManager.hurtMulti);
            SceneManager.LoadScene(nextScene);

        }
    }
}
