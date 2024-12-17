using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    [Header("DogSettings")]
    public float accelerateFactor = 30.0f;
    public float turnFactor =  3.0f;
    public float driftFactor = 1f;
    public float maxSpeed = 2f;
    public bool dogIsAlive = true;
    public AudioClip playerDeath;
    public GameObject dogDie;
    public GameObject bullet;
    public GameObject shield;

    //local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float velocityVsUp = 0;
    private float timeBetweenBulletSpawns = 0.1f;
    public int ammoCount = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
        shield = transform.Find("Shield").gameObject;
    }

   public float speed = 10f; 
   public float rotateSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (dogIsAlive)
        {
            ApplyEngineForce();
            KillOrthogonalVelocity();
            ApplySteering();
        }

    }

    void ApplyEngineForce()
    {
        //Forward speed
        velocityVsUp = Vector2.Dot(transform.up, myRigidbody.velocity);
        //Fwd speed limit
        if (velocityVsUp > maxSpeed) //&& accelerationInput > 0)
            return;
        //Reverse limit = 0.4 * limit
        if (velocityVsUp < -maxSpeed*0.4f && accelerationInput < 0)
            return;

        //if (accelerationInput == 0)
        myRigidbody.drag = Mathf.Lerp(myRigidbody.drag, 1.0f, Time.fixedDeltaTime * 2);
        //else myRigidbody.drag = 0;
        //Create Engine Force
        Vector2 engineForceVector = transform.up * accelerateFactor; //*accelerationInput

       //Apply Force
        myRigidbody.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= steeringInput * (turnFactor*Time.deltaTime*350);
        myRigidbody.MoveRotation(rotationAngle);     
    }

    void KillOrthogonalVelocity()    
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(myRigidbody.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(myRigidbody.velocity, transform.right);

        myRigidbody.velocity = forwardVelocity + rightVelocity * driftFactor;

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   

        if(collision.gameObject.CompareTag ("Sheep"))
        {
            logic.gameOver();
            dogIsAlive = false;
        }
        //myRigidbody.SetActive(false);
        //Destroy(gameObject);
    }

    public void DogDie()
    {
        Instantiate(dogDie, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(playerDeath,Vector3.zero,1f);
        Destroy(gameObject);
    }

    public void machineGunPowerup()
    {
        StartCoroutine(bulletSpawn());
    }

    public void shotGunPowerup()
    {
        for(int i = 0; i < ammoCount; i++)
        { 
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, i*360f/ammoCount));
        }
    }
    public void shieldPowerup()
    {
        StartCoroutine(shieldPowerupWaiter());
    }

    IEnumerator bulletSpawn()
    { 
        for(int i = 0; i < ammoCount; i++)
        { 
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds (timeBetweenBulletSpawns);
        }
    }
    IEnumerator shieldPowerupWaiter()
    { 
        shield.SetActive(true);         
        yield return new WaitForSeconds (5f);
        shield.SetActive(false);
    }
}
