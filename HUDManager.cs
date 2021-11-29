using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private int totalHazardCount;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onHazardInit += OnHazardInit;
        GameManager.Instance.onHazardSelected += OnHazardSelected;

        GameManager.Instance.HazardInit();
    }

    private void OnHazardInit(int hazardCount)
    {
        totalHazardCount = hazardCount;
        GameObject textObj = gameObject.transform.GetChild(0).gameObject;
        textObj.GetComponent<Text>().text = $"0 / {hazardCount.ToString()}";
    }

    private void OnHazardSelected(string hazardId, int numIdentified)
    {
        GameObject textObj = gameObject.transform.GetChild(0).gameObject;
        textObj.GetComponent<Text>().text = $"{numIdentified.ToString()} / {totalHazardCount.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
