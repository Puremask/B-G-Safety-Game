using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineSparks : MonoBehaviour
{
    public ParticleSystem Sparks;
    public ParticleSystem Smoke;
    public MenuManager menu;
    public Panel losePanel;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        losePanel.Hide();  
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        Sparks.Play();
        Smoke.Play();
        audio.Play();
        //menu.SetCurrentWithHistory(losePanel);
       // menu.Pause();
    }
}
