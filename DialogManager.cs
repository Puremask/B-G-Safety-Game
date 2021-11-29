using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onNewDialog += OnNewDialog;
        GameManager.Instance.onHazardInit += OnHazardInit;
        GameManager.Instance.HazardInit();
    }

    private void OnNewDialog(string message)
    {
        GameObject textObj = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        textObj.GetComponent<Text>().text = message;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnHazardInit(int totalHazards)
    {
        GameObject textObj = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        textObj.GetComponent<Text>().text = $"Welcome to SAFESim jobsite safety simulation. There are {totalHazards.ToString()} unsafe conditions in this construction scene. Can you find them all?";

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
