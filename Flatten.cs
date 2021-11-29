using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flatten : MonoBehaviour
{
    public GameObject worker;
    public ParticleSystem spurt;
    public AudioSource crack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        crack.Play();
        worker.SetActive(false);
        spurt.Play();
    }
}
