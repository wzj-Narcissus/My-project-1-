using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player;
    PlayerManager playerManager;
    public float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(Vector2 target)
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, attackSpeed * Time.deltaTime);
        playerManager.theRB.velocity = target.normalized*attackSpeed;
    }
}
