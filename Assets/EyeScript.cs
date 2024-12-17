using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public Sprite playerSheet_0, playerSheet_1, playerSheet_2;
    public SpriteRenderer spriteRenderer;
    float horizontalInput = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
                //handle animations
        if (horizontalInput < 0){
            spriteRenderer.sprite = playerSheet_0;
        }
        else if(horizontalInput > 0){
            spriteRenderer.sprite = playerSheet_2;
        }
        else
        {
            spriteRenderer.sprite = playerSheet_1;
        }
    }
}
