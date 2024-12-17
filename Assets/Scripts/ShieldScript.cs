using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour

{
    public Color startObjectColor;
    // Start is called before the first frame update
    void Awake()
    {
        //Color startObjectColor = gameObject.GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            Color startObjectColor = gameObject.GetComponent<SpriteRenderer>().material.color;
            Color objectColor = gameObject.GetComponent<SpriteRenderer>().material.color;
            float alpha = objectColor.a - 0.2f * Time.deltaTime;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, alpha);
            gameObject.GetComponent<SpriteRenderer>().material.color = objectColor;    
        }
 
    }

    void OnDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Sheep"))
        {            
            collision.gameObject.GetComponent<SheepBehavior>().SheepDie();
        }
    }
}
