using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : MonoBehaviour
{
    /*
     * AUTHOR: Cole Spencer
     * 
     * So my thought processes behind this script are that I want to have several time sensitive hazards.
     * I want the hazards to perform their animation sequences in a random order, at random intervals of time (in seconds).
     * To do that I decided to use a list, that way i can remove objects, and the .count changes on a Remove() func call.
     * I used Unity's proprietary animation handler and called those triggers in this script.
    */

    // VARIABLES
    public int haz = 2;
    public int ident = 0;
    public int lasthaz;
    public float time;
    public bool active = false;
    public Animator craneAnim;
    public Animator exeAnim;
    public Animator throwAnim;
    public Animator impale;
    public GameManager gm;
    public GameObject netHaz;
    public Rigidbody beams;
    public AudioSource snap;


    public List<Action> hazards1 = new List<Action>(); //a list of actions (methods)
    


    //METHODS
    void Start() // Start is called before the first frame update
    {
        hazards1.Add(Crane);
        hazards1.Add(Exe);
        hazards1.Add(Throw);
        hazards1.Add(Impale);
        hazards1.Add(Flatten); //adding methods to the list to reference later
        StartCoroutine(waiter());
    }
    IEnumerator waiter() // couroutine to wait a random range of seconds and then to pick a random hazard each time the method is called.         
    {
        active = true;
        int wait_time = UnityEngine.Random.Range(20, 45); //random range for wait 
        Debug.Log("waiting for " + wait_time + "seconds!");
        yield return new WaitForSeconds(wait_time);
        int hazard = UnityEngine.Random.Range(0, hazards1.Count); //random range for haz selection
        Debug.Log(hazard);
        hazards1[hazard].Invoke(); //calls method action from list
        hazards1.RemoveAt(hazard); //removes specified hazard from list and also changes the count, unlike an array
    }

    //PUBLIC METHODS
    public void RemoveImpale() {
        hazards1.Remove(Impale);
        if (!active) StartCoroutine(waiter());
    }

    public void RemoveFlatten()
    {
        hazards1.Remove(Flatten);
        if (!active) StartCoroutine(waiter());
    }
    public void RemoveThrow()
    {
        hazards1.Remove(Throw);
        if (!active) StartCoroutine(waiter());
    }
    public void Flatten() {
        Debug.Log("Flattened!");
        snap.Play();
        active = false;
        beams.isKinematic = false;
        ident++;
        StartCoroutine(waiter());
    }

    public void Impale() {
        Debug.Log("Impale");
        active = false;
        impale.SetTrigger("Impale");
        ident++;
        StartCoroutine(waiter());
    }
    public void Crane() {
        Debug.Log("Crane!");
        active = false;
        craneAnim.SetTrigger("Crane");
        ident++;
        StartCoroutine(waiter());
    }
    public void Exe() //the method executing the crawler crane hazard sequence.
    {
        Debug.Log("Exe!");
        active = false;
        exeAnim.SetTrigger("Excavator");
        ident++;
        StartCoroutine(waiter());                    
    }

    public void Throw() {
        Debug.Log("Throw!");
        active = false;
        netHaz.SetActive(true);
        throwAnim.SetTrigger("Throw");
        ident++;
        StartCoroutine(waiter());
    }



}
