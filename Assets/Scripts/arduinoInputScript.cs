using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arduinoInputScript : MonoBehaviour
{
    // Start is called before the first frame update
    //SerialPort data_strem = new SerialPort("COM3", 9600);
    public string recivedString;
    public bool[] buttons;

    public string[] datas;
    void Start()
    {
        //data_strem.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        //recivedString = data_strem.ReadLine();

        string[] datas = recivedString.Split(',');

        if (datas[0] == "1")
        {
            buttons[0] = true;
        }
        else
        {
            buttons[0] = false;
        }

        if (datas[1] == "1")
        {
            buttons[1] = true;
        }
        else
        {
            buttons[1] = false;
        }

        if (datas[2] == "1")
        {
            buttons[2] = true;
        }
        else
        {
            buttons[2] = false;
        }

        if (datas[3] == "1")
        {
            buttons[3] = true;
        }
        else
        {
            buttons[3] = false;
        }
    }
}
