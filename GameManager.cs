using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour //This script defines the dictionaries and level based variables that run hazards and their interactions with the player.
    //This code has been written be both Jake L, and Cole S.
{
    private static GameManager _instance;
    private static Dictionary<int, Dictionary<string, bool>> Level;
    public int hazardCount;
    public int identified;
    public Panel winPanel = null;
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;
    public MenuManager menu;
    public GameObject pointer;
    public GameObject pointer2;
    static bool isEnabled = true;
    int sceneIndex;
    public float timeRemaining = 20;
    bool timerOn = false;
    static bool easyMode = false;
    public GameObject easyCheck;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public void EasyMode() { //toggle if statements that turn on and off the easy mode as well as the UI check within the options menu
        if (easyMode) {
            easyMode = false;
            easyCheck.SetActive(false);
        }
        else
        {
            easyMode = true;
            easyCheck.SetActive(true);
        }
    }

    private void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.One)) //toggle function for the laser pointer
            {
            if (isEnabled)
            {
                Off();

            }
            else {
                On();
            }
        }

        if (timerOn && easyMode) { //runs the timer for easy mode
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
            }
            else {
                ArrowEnable();
                timeRemaining = 0;
                timerOn = false;
                Debug.Log("Time is up!");
            }
        }
    }

    public void ArrowEnable() { //enables all active arrows helping the player when time is up
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Arrows");
        foreach (GameObject go in gameObjectArray)
        {
            go.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void WinChecker() { //checks to see if the hazards have all been selected and shows the win menu when done so
        if (hazardCount.Equals(identified) && SceneManager.GetActiveScene().buildIndex > 1)
        {
            if (SceneManager.GetActiveScene().buildIndex.Equals(2))
            {
                level1 = true;
            }
            if (SceneManager.GetActiveScene().buildIndex.Equals(3))
            {
                level2 = true;
            }
            if (SceneManager.GetActiveScene().buildIndex.Equals(4))
            {
                level3 = true;
            }
            menu.SetCurrentWithHistory(winPanel);
            menu.Pause();
        }

    }

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        winPanel.Hide();
        timerOn = true; //start the timer
    }

    void Awake()
    {
        XRSettings.eyeTextureResolutionScale = 1.5f; //rescale menu GUI eye resolution for quest benefit
        _instance = this;
        Level = new Dictionary<int, Dictionary<string, bool>>();
        Level[1] = new Dictionary<string, bool>() //level 1 hazards
        {
            {"no_barrier", false},
            {"trenchbox_too_high", false},
            {"debris_in_excavation", false},
            {"spoil_pile_too_close", false},
            {"no_railing", false},
            {"water_in_excavation", false},
            {"improper_shoring", false},
            {"digging_on_utility", false },
            {"surface_encumbrance", false },


        };
        Level[2] = new Dictionary<string, bool>() //level 2 hazards
        {
            {"no_barrier", false },
            {"no_toeboards", false},
            {"no_mudsills", false},
            {"improper_ppe", false},
            {"fall_protection", false},
            {"inspection_tag", false},
            



        };
        Level[3]= new Dictionary<string, bool>() //level 3 hazards
        {
            {"power_lines", false},
            {"utility_digging", false},
           // {"overhead_debris", false},
            {"impale", false },
            {"flatten", false },
        };
    }


    public event Action<string> onNewDialog;
    public void NewDialog(string message)
    {
        onNewDialog?.Invoke(message);
    }

    public event Action<string, int> onHazardSelected;
    public void HazardSelected(string hazardId)
    {
            int identifiedCount = Level[sceneIndex].Values.Where(v => v).Count();
            identified = identifiedCount;
            Level[sceneIndex][hazardId] = true;
            onHazardSelected?.Invoke(hazardId, identifiedCount);
    }

    public event Action<int> onHazardInit;
    public void HazardInit() //initialization for however many hazards there are per level
    {
            hazardCount = Level[sceneIndex].Count;
            
            onHazardInit?.Invoke(hazardCount);
    }

    public void On() { //pointer on function
        isEnabled = true;
        pointer.SetActive(true);
        pointer2.SetActive(true);
    }
    public void Off() { //pointer off function
        isEnabled = false;
        pointer.SetActive(false);
        pointer2.SetActive(false);

    }
}
