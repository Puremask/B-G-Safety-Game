using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour //Menu Behavior and function script. 
    //Written by Cole S, but essentially just a very closely followed youtube tutorial. Quickly googlable.
{
    public Panel currentPanel = null;

    private List<Panel> panelHistory = new List<Panel>();

    public static bool isPaused = false;

    public RawImage Check1;

    public RawImage Check2;

    public RawImage Check3;

    public void Pause() //pauses the games time and shows the menu
    {
        currentPanel.Show();
        isPaused = true;
    }

    public void Resume() //resumes the games time and rids the menu
    {
        currentPanel.Hide();
        isPaused = false;
    }

    private void Start()
    {
        SetupPanels();
        isPaused = false;
        if (SceneManager.GetActiveScene().buildIndex > 1) {
            Resume();
        }
        
    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels)
            panel.Setup(this);
            currentPanel.Show();

        if (SceneManager.GetActiveScene().buildIndex > 1) //if not on the main menu or tutorial do not show the menu initially
            currentPanel.Hide();

        if (SceneManager.GetActiveScene().buildIndex.Equals(0)) //if the main menu starts, then disable the check marks for the levels
        {
            Check1.enabled = false;
            Check2.enabled = false;
        }
    }

    private void Update()
    {
        if (GameManager.level1) //if level one is complete, then enable the check mark on the menu
        {
            Check1.enabled = true;
        }
        if (GameManager.level2) // if level 2 is completed, enable the check on the main menu
        {
            Check2.enabled = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two)) //if the back button is pushed
            GoToPrevious();

        if (OVRInput.GetDown(OVRInput.Button.Start) && SceneManager.GetActiveScene().buildIndex > 1) //pause toggle function
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void GoToPrevious() //go to the previous menu panel
    {
        if (panelHistory.Count == 0)
            return;

        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);

    }

    public void SetCurrentWithHistory(Panel newPanel) //set the new panel
    {
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);
    }

    public void SetCurrent(Panel newPanel) //sets the current panel
    {
        currentPanel.Hide();
        currentPanel = newPanel;
        currentPanel.Show();
    }

}
