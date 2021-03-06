using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    [SerializeField]
    float moveSpeed;
    
    [SerializeField]
    float timeLimit;

    float timer = 0;
    float timerDelay = 0;

    [SerializeField]
    float delay;

    [SerializeField]
    Vector2 dir = Vector2.left;

    SpriteRenderer spr;

    void Awake() {
        spr = GetComponent<SpriteRenderer>(); 
    }

    void Update() {

        /*transform.Translate(dir * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if(timer >= timeLimit)
        {
            timer = 0;
            dir.x = dir.x > 0 ? -1 : 1;
            spr.flipX = FlipSprite;
        }*/

        
        
        if(timer <= timeLimit)
        {
            transform.Translate(dir * moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            timerDelay += Time.deltaTime;
            if(timerDelay >= delay)
            {
                dir.x = dir.x > 0 ? -1 : 1;
                spr.flipX = FlipSprite;
                timer = 0;
                timerDelay = 0;

            }
        }


        
    }

    bool FlipSprite
    {
        get => dir.x > 0 ? true : false;
    }
}
