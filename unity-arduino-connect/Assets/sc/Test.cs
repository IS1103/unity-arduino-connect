using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image img;
    void Start()
    {
        ArduinoConnector.receiveEvent = ReceiveEvent;
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
        
        ArduinoConnector.writeEvent("1");
    }
}
