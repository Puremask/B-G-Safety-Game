using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Panel : MonoBehaviour //Simple panel definition function
{
    private Canvas canvas = null;
    private MenuManager menuManager = null;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    public void Setup(MenuManager menuManager) { // setup for menuManager and hiding panels on setup
        this.menuManager = menuManager;
        Hide();
    }

    public void Show() { //these bottom functions are very simple and self explanatory, the first shows the currently hidden panel, the latter hides the currently showing panel
        canvas.enabled = true;
    }

    public void Hide() {  //
        canvas.enabled = false;
    }


}
