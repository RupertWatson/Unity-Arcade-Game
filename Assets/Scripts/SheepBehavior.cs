using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehavior : MonoBehaviour
{
    public GameObject dog;
    public GameObject sheepDie;
    public GameObject sheepToken_1;
    //public GameObject sheepToken_2;
    //public GameObject sheepToken_3;
    public float moveSpeed = 2;
    public float turnSpeed = 180;
    public LogicScript logic;

    public float idleTime = 0.4f;
    private float timer = 0;



    void Awake()
    {
        dog = GameObject.FindWithTag("PlayerDog");
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    
    {
        if (timer < idleTime)
        {
            timer += Time.deltaTime;
        }
        
        else if(dog != null)
        {
            Vector3 target = dog.transform.localPosition;
            transform.localPosition = Vector3.MoveTowards (transform.localPosition, target, Time.deltaTime * moveSpeed);
            
            Vector3 myLocation = transform.position;

            Vector3 vectorToTarget = target - myLocation;
            Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 0) * vectorToTarget;

            Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        else //victory spin
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
    }
    
    public void SheepDie()
    {
        GameObject sheepDead = Instantiate(sheepDie, transform.position, transform.rotation);
        sheepDead.transform.localScale = transform.localScale;
        sheepDead.GetComponent<SpriteRenderer>().material.color = GetComponent<SpriteRenderer>().material.color;

        //Spawn 2-5 Tokens
        for (var i=0; i<Random.Range(2,5); i++)
        {
            Vector3 spawnLocate = transform.position + new Vector3(Random.Range(-0.3f,0.3f) , Random.Range(-0.3f,0.3f),0);
            Instantiate(sheepToken_1, spawnLocate,  Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));          
        }
        
        //logic.addScore(1);
        Destroy(gameObject);
    }

}
