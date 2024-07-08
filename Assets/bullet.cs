using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector2 m_Position;
    public float speed = 10;
    public float livetime = 3f;
    private float _time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time>livetime)
        {
            Destroy(gameObject);
        }
        transform.Translate(m_Position*(speed*Time.deltaTime));
    }
    public void setdirection(Vector2 dir)
    { m_Position = dir; }
}
