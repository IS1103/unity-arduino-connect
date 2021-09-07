using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public ArduinoConnector arduinoConnector;
    public Image img;
    void Start()
    {
        arduinoConnector.receiveEvent = ReceiveEvent;
    }

    private void ReceiveEvent(string msg)
    {
        
        if (msg.Trim() == "A")
        {
            Debug.Log(msg);
            img.color = Color.green;
        }
        else if(msg.Trim() == "B")
        {
            Debug.Log(msg);
            img.color = Color.red;
        }
        else if (msg.Trim() == "C")
        {
            Debug.Log(msg);
            img.color = Color.yellow;
        }
    }

    public void ClickBtn() {

        arduinoConnector.writeEvent("1");
    }
}
