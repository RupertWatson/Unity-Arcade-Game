using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    public GameObject powerup;
    public float powerupSpawnRate = 10;
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < powerupSpawnRate + 5)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPowerup();  
            timer = 0;
        }
    }
    
    void spawnPowerup()
    { 
        Vector3 laserItemPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-5.5f, 5.5f), 0);
        Quaternion laserItemRotation = Quaternion.Euler(0, 0, Random.Range(-180f,180f));
        Instantiate(powerup, laserItemPosition, laserItemRotation);
    }
}
