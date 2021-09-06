using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class ArduinoConnector : MonoBehaviour
{
    public int baud;
    public string portName;

    public static Action<string> receiveEvent, writeEvent;

    private SerialPort arduinoStream;
    private string readMessage;

    void Start()
    {
        if (!string.IsNullOrEmpty(portName) && baud != 0)
        {
            writeEvent = WriteEvent;
            arduinoStream = new SerialPort(portName, baud);
            try
            {
                arduinoStream.Open();
                Debug.Log("SerialPort開啟連接");
            }
            catch (Exception ex)
            {
                Debug.Log("SerialPort連接失敗:"+ ex.Message);
            }
        }
    }

    private void WriteEvent(string msg)
    {
        Debug.Log(msg);
        try
        {
            arduinoStream.Write(msg);
        }
        catch (Exception ex)
        {
            Debug.Log("傳送資料給 arduino 失敗:" + ex.Message);
        }
    }

    private void Update()
    {
        if (arduinoStream.IsOpen)
        {
            try
            {
                readMessage = arduinoStream.ReadLine();
                //Debug.Log(readMessage);
                receiveEvent?.Invoke(readMessage);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    void OnApplicationQuit()
    {
        if (arduinoStream != null)
        {
            if (arduinoStream.IsOpen)
            {
                arduinoStream.Close();
            }
        }
    }
}
