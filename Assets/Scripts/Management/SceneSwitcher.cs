using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

   // private GameObject audioManagerObject;
    private AudioManager audioManager;

        private void Start() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    
    private void Awake(){
        DontDestroyOnLoad(gameObject);

    }

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    public void goToMenu(){
        GameObject canvasObject = GameObject.Find("Canvas");  

            if (canvasObject != null)
                  {
                   Destroy(canvasObject);
                  }
          audioManager.StopMusic();
        SceneManager.LoadScene("Main Menu");
    }
    

    public void quitApp(){
        Debug.Log("qiut");
        Application.Quit();
    }

}
    
     


