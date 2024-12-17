using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public GameObject[] bombs;
    public float bombSpawnRate = 3;
    public int maxBombCount = 2;
    private float timer = 0;

    public AudioClip bombSpawnSound;
    //private float spawnRangeFromCenter = 300f; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer < bombSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            
            if (GameObject.FindGameObjectsWithTag("Bomb").Length < maxBombCount)
            {
                spawnBomb();  
                timer = 0;
            }

        }
    }
    void spawnBomb()
    {       
        Vector3 bombSpawnPosition = new Vector3(Random.Range(-13f, 13f), Random.Range(-6f, 6f), 0);
        Instantiate(bomb, bombSpawnPosition, transform.rotation);
        AudioSource.PlayClipAtPoint(bombSpawnSound,bombSpawnPosition,1f);
    }
}
