using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D theRB;
    public float speed;

    public float minDistance = 0.1f; 
    public float maxDistance = 10.0f; 

    private Vector2 targetPosition; 

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distance = Vector2.Distance(transform.position, targetPosition);

        float moveSpeed = speed * (distance / maxDistance);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }
}
