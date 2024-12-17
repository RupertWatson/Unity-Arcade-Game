using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInputHandler : MonoBehaviour
{

    //components
    DogScript DogScript;

    void Awake()
    {
        DogScript = GetComponent<DogScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        DogScript.SetInputVector(inputVector);

    }
}
