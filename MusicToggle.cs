using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour //simple toggle methods for muting/unmuting the music and displaying an image based on the toggle
{
    public RawImage on;
    public RawImage off;

    public void Start()
    {
        off.enabled = false;
    }
    public void OnChangeValue()
    {
        bool onoff = gameObject.GetComponent<Toggle>().isOn;

        if (onoff)
        {
            on.enabled = false;
            off.enabled = true;
        }
        else
        {
            on.enabled = true;
            off.enabled = false;
        }
    }
}
