﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Refocus : MonoBehaviour {
    GameObject lastSelect;
    void Start()
    {

        lastSelect = new GameObject("ButtonSelected");
  
    }
    // Update is called once per frame
    void Update () {
		if(EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
	}
}
