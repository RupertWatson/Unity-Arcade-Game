using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBox : MonoBehaviour
{
    public GameObject laser;
    public float fadeRate = 0.2f;
    public AudioClip upgradeSound;
    public GameObject player;
    public float turnSpeed = 15f;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1f/fadeRate);
        player = GameObject.FindWithTag("PlayerDog");
        turnSpeed = Random.Range(-20f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        Color objectColor = gameObject.GetComponent<SpriteRenderer>().material.color;
        float alpha = objectColor.a - fadeRate * Time.deltaTime;

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, alpha);
        gameObject.GetComponent<SpriteRenderer>().material.color = objectColor;

        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        transform.position = transform.position + (transform.up * moveSpeed) *Time.deltaTime;

        //turnSpeed = turnSpeed + (1*Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("PlayerDog"))
        {
            switch(Random.Range(0,3))
        {
            case 0:
                //Activate machinegun upgrade
                player.GetComponent<DogScript>().machineGunPowerup();
               // GameObject.FindWithTag("PlayerDog").GetComponent<DogScript>().machineGunPowerup();
            break;
            case 1:
                //Activate shield upgrade             
                player.GetComponent<DogScript>().shotGunPowerup();
            break;
            case 2:
                //Activate shield upgrade  
                player.GetComponent<DogScript>().shieldPowerup();           
            break;
        } 
        AudioSource.PlayClipAtPoint(upgradeSound,Vector3.zero,1f);
        Destroy(gameObject);
        }
    }
}
