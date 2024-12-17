using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour    
{
    public GameObject blast;
    public GameObject dog;
    private float turnSpeed = 20;
    public float blastRadius = 2f;
    public LogicScript logic; 
    public AudioClip explodeClip;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindWithTag("PlayerDog");
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(dog != null)
        // {
        //     Vector3 target = dog.transform.localPosition;
        //     Vector3 myLocation = transform.position;
        //     Vector3 vectorToTarget = target - myLocation;
        //     Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 0) * vectorToTarget;

        //     Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        // }
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("PlayerDog"))
        {
            Instantiate(blast, transform.position, transform.rotation);
            logic.addBombScore(1);
            AudioSource.PlayClipAtPoint(explodeClip,transform.position,1f);
            Destroy(gameObject);     
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, blastRadius);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.gameObject.CompareTag("Sheep"))
                {
                    hitCollider.gameObject.GetComponent<SheepBehavior>().SheepDie();
                    
                }
            }
        }
    }

}
