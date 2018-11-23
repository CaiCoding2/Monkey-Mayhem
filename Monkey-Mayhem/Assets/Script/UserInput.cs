using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour
{
    public GameObject nameSubmitHolder;
    public GameObject Button;
    public static InputField input;

    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void GetInput(string name)
    {
        Debug.Log("You have entered: " + name);
        input.text = "";
        Highscores.AddNewHighscore(name, ScoreTextScript.total);
        nameSubmitHolder.SetActive(false);
        EventSystem.current.SetSelectedGameObject(Button);
    }
}