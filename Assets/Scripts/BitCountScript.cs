using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitCountScript : MonoBehaviour
{
    public Text bitCountText;
    // Start is called before the first frame update
    void Start()
    {
        bitCountText.text =$"BITS: {PlayerPrefs.GetInt("BitCount", 0)}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
