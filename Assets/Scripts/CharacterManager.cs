using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;
    public GameObject[] selectedCharacterSprite;
    public Button unlockButton;
    public int playerFunds;
    public Text playerFundsText;
    public AudioClip buttonSound;
    public AudioClip unlockSound;

    private void Awake() 
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter",0);
        playerFunds = PlayerPrefs.GetInt("BitCount",0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        foreach(Character c in characters)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                if  (PlayerPrefs.GetInt(c.name, 0)==0)
                {
                    c.isUnlocked = false;
                }
                else
                {
                    c.isUnlocked = true;
                }
                
            }
        }
        UpdateUI();
    }   


    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;
              
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked==true)
            UpdateCharacter(selectedCharacter);
        UpdateUI();
        AudioSource.PlayClipAtPoint(buttonSound,Vector3.zero,1f);
    }
    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length -1;

        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked==true)
            UpdateCharacter(selectedCharacter);
        UpdateUI();
        AudioSource.PlayClipAtPoint(buttonSound,Vector3.zero,1f);
    }

    public void UpdateCharacter (int selectedCharacter)
    {
        PlayerPrefs.SetInt("selectedCharacter",selectedCharacter);
    }

    public void UpdateUI()
    {
        playerFundsText.text = "BITS: "+ PlayerPrefs.GetInt("BitCount",0); 
        if(characters[selectedCharacter].isUnlocked==true)
            unlockButton.gameObject.SetActive(false);
        else
        {
            unlockButton.GetComponentInChildren<Text>().text = "Price: "+ characters[selectedCharacter].price;
            if(PlayerPrefs.GetInt("BitCount",0) <= characters[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
                selectedCharacterSprite = GameObject.FindGameObjectsWithTag("selectableCharacter");
                foreach(GameObject Sprite in selectedCharacterSprite)
                {
                    Sprite.GetComponent<SpriteRenderer>().material.color = new Color(0.1f,0.1f,0.1f);
                }
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;  
            }
        }
    }

    public void unlockCharacter()
    {
        characters[selectedCharacter].isUnlocked=true;
        PlayerPrefs.SetInt("BitCount", (PlayerPrefs.GetInt("BitCount",0) - characters[selectedCharacter].price));
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        UpdateUI();
        UpdateCharacter(selectedCharacter);
        AudioSource.PlayClipAtPoint(unlockSound,Vector3.zero,1f);
    }
}
