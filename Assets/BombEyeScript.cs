using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEyeScript : MonoBehaviour
{
    private float turnSpeed = 180;
     public GameObject dog;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindWithTag("PlayerDog");
    }

    // Update is called once per frame
    void Update()
    {
        if(dog != null)
        {
            Vector3 target = dog.transform.localPosition;
            Vector3 myLocation = transform.position;
            Vector3 vectorToTarget = target - myLocation;
            Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 0) * vectorToTarget;

            Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}
