using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipX : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flipx(SpriteRenderer spriteRenderer,Vector2 direction)
    {
        if(direction.x>0)spriteRenderer.flipX= true;
        if(direction.x<0) spriteRenderer.flipX = false;
    }
}
