using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationScript : MonoBehaviour
{
    [SerializeField] private Vector2 initialPosition;
    [SerializeField] private Vector2 middlePosition;
    [SerializeField] private Vector2 finalPosition;

    // Start is called before the first frame update
    private void Awake()
    {
         initialPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
       
        transform.position = Vector3.Lerp(transform.position, finalPosition,0.01f);
    }

    private void OnDisable()
    {
       
        transform.position = initialPosition;
    }
}
