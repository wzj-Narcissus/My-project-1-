using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Treasurebox : MonoBehaviour
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
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
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
            //‘ˆº” Ù–‘
            PlayerPrefs.SetFloat("10", playerManager.getMoneyRate);
            PlayerPrefs.SetFloat("11", playerManager.intShield);
            PlayerPrefs.SetFloat("12", playerManager.inthurt);
            PlayerPrefs.SetFloat("13", playerManager.monsterHealth);
            PlayerPrefs.SetFloat("14", playerManager.monsterMissRate);
            PlayerPrefs.SetFloat("15", playerManager.intMonsterShield);
            SceneManager.LoadScene(nextScene);
            Destroy(gameObject);
        }
    }
}
