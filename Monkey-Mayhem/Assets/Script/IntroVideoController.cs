using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideoController : MonoBehaviour {

    void Start()
    {
         StartCoroutine(LoadLevelAfterDelay(20));
    }

    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space) 
            || Input.GetKeyDown(KeyCode.Joystick1Button0) 
            || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
         {    
             yield return new WaitForSeconds(delay);
             SceneManager.LoadScene("Menu");            
         }
}
