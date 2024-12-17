using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    private float moveSpeed = 5f;
    public LogicScript logic;
    public GameObject dog;
    public AudioClip pickupSound;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindWithTag("PlayerDog");
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dog != null)
        {
        Vector3 target = dog.transform.localPosition;
        float distanceToTarget = Vector3.Distance(target,transform.localPosition);

        transform.localPosition = Vector3.MoveTowards (transform.localPosition, target, (Time.deltaTime * moveSpeed)/distanceToTarget);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.CompareTag ("PlayerDog"))
        {
            Destroy(gameObject); 
            logic.addScore(1);
            AudioSource.PlayClipAtPoint(pickupSound,transform.localPosition,1f);
        }
    }

}
