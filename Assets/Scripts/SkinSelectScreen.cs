using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelectScreen : MonoBehaviour

{
    public AudioClip buttonSound;
    public void ReturnMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        AudioSource.PlayClipAtPoint(buttonSound,Vector3.zero,1f);
    }

   public void Play()
    {
        SceneManager.LoadSceneAsync("Level1");
        AudioSource.PlayClipAtPoint(buttonSound,Vector3.zero,1f);
    }
}


