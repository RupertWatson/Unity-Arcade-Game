using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawnerScript : MonoBehaviour
{
    public GameObject sheep;
    public GameObject dog;
    public float timer = 1f;
    public float spawnRate = 3f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<spawnRate){
            timer = timer+ Time.deltaTime;

        }
        else
        {
            SpawnPlayer();
            timer = 0;
        }
    }

    void SpawnPlayer()
    {
        Debug.Log("spawnSheep");
        Instantiate(sheep, transform.position, transform.rotation);    
    }

    
}
