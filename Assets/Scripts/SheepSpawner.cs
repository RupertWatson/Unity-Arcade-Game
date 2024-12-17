using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public GameObject[] PlayerPrefabs;
    public GameObject dog;
    public GameObject sheep_1;
    public float spawnRate = 4;
    private float timer = 0;
    public AudioClip sheepSpawnSound;
    private float borderWidthx = 15f;
    private float borderWidthy = 8.8f;

    int selectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter",0);
        Instantiate(PlayerPrefabs[selectedCharacter], Vector3.zero, Quaternion.Euler(0, 0, 0) );
        dog = GameObject.FindWithTag("PlayerDog");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        { 
            spawnSheep();  
            timer = 0;
            spawnRate = spawnRate - (0.005f*spawnRate);
        }
        
    }        
    void spawnSheep()
    {        
        Vector3 sheepSpawnLocation = new Vector3();
        //Create random location on outer square --Make sure not too close to player
        switch(Random.Range(0,4))
        {
            case 0:
                sheepSpawnLocation = new Vector3(Random.Range(-borderWidthx,borderWidthx),borderWidthy,0f);
            break;
            case 1:
                sheepSpawnLocation = new Vector3(Random.Range(-borderWidthx,borderWidthx),-borderWidthy,0f);
            break;
            case 2:
                sheepSpawnLocation = new Vector3(borderWidthx,Random.Range(-borderWidthy,borderWidthy),0f);
            break;
            case 3:
                sheepSpawnLocation = new Vector3(-borderWidthx,Random.Range(-borderWidthy,borderWidthy),0f);
            break;
        }

        //Starting rotation
        Vector3 target = dog.transform.localPosition;
        Vector3 vectorToTarget = target - sheepSpawnLocation;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 0) * vectorToTarget;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        //Spawn sheep
        GameObject newSheep = Instantiate(sheep_1, sheepSpawnLocation, targetRotation);
        float newScale = Random.Range( 0.6f,1.6f);
        newSheep.transform.localScale = new Vector3(newScale,newScale,1);
        newSheep.GetComponent<SheepBehavior>().moveSpeed = sheep_1.GetComponent<SheepBehavior>().moveSpeed*(1/newScale);
       
        Color sheepColor = new Color(1, 1.6f-newScale, 0, 1);
        newSheep.GetComponent<SpriteRenderer>().material.color = sheepColor;

        AudioSource.PlayClipAtPoint(sheepSpawnSound,Vector3.zero,0.5f);
    }
}
