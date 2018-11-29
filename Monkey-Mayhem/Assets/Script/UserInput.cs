using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UserInput : MonoBehaviour
{
    public GameObject SubmitName; //variable to set setactive(false) after name submission
    public GameObject SubmitButton; //variable to set setactive(false)
    public static Text warning;
    public static InputField input; //gets user input
    private string charName; //used to debug and print user input

    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        warning = GameObject.Find("WarningText").GetComponent<Text>();
    }

    public static bool IsAllLetters(string s)
    {
        foreach (char c in s)
        {
            if (!Char.IsLetter(c))
                return false;
        }
        return true;
    }

    public void OnSubmit()
    {
        if (!string.IsNullOrEmpty(input.text) && IsAllLetters(input.text))
        {
            charName = input.text;
            Debug.Log("You have entered: " + charName);
            Highscores.AddNewHighscore(charName, ScoreTextScript.total);
            SubmitName.SetActive(false);
            SubmitButton.SetActive(false);
            warning.text = "";
        }
        else
        {
            warning.text = "Alphabetic characters only!";
        }
    }
}