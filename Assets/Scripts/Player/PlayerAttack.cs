using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    public float attackSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(int damage,Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, attackSpeed * Time.deltaTime);
    }
}
