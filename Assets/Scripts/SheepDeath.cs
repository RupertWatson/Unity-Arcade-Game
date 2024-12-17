using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour
{
    public float fadeRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        Color objectColor = gameObject.GetComponent<SpriteRenderer>().material.color;
        float alpha = objectColor.a - fadeRate * Time.deltaTime;

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, alpha);
        gameObject.GetComponent<SpriteRenderer>().material.color = objectColor;
    }
}
