using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    public GameObject dog;
    public GameObject sheepDie;
    public GameObject sheepToken;
    private float moveSpeed = 2;
    private float turnSpeed = 180;
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
            Vector3 myLocation = transform.position;
            Vector3 vectorToTarget = target - myLocation;
            Vector3 movementVector = Vector3.down;
            
            if (Mathf.Abs(vectorToTarget.y) < Mathf.Abs(vectorToTarget.x)) //horizontal
            {
                if (vectorToTarget.x>0){
                    movementVector = Vector3.right;
                    transform.rotation = Quaternion.Euler(0,0,270); 
                }
                else{
                    movementVector = Vector3.left;  
                    transform.rotation = Quaternion.Euler(0,0,90);   
                }
                transform.Translate(movementVector * moveSpeed * Time.deltaTime,Space.World);
            }
            else
            {
                if (vectorToTarget.y>0){
                    movementVector = Vector3.up;
                    transform.rotation = Quaternion.Euler(0,0,0); 
                }
                else{
                    movementVector = Vector3.down;  
                    transform.rotation = Quaternion.Euler(0,0,180);   
                }
                transform.Translate(movementVector * moveSpeed * Time.deltaTime,Space.World);
            }
            
            

        }
        else //victory spin
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
    }
    
    public void SheepDie()
    {
        Instantiate(sheepDie, transform.position, transform.rotation);
        //Spawn 2-5 Tokens
        for (var i=0; i<Random.Range(2,5); i++)
        {
            Vector3 spawnLocate = transform.position + new Vector3(Random.Range(-0.3f,0.3f) , Random.Range(-0.3f,0.3f),0);
            Instantiate(sheepToken, spawnLocate, transform.rotation);    
        }
        
        //logic.addScore(1);
        Destroy(gameObject);
    }

}
