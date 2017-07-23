using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Exemple2 : ScriptTemplateForUI
{
    // Use this for initialization
    void Start()
    {
        chatTextUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    /// <summary>
    /// /// Send a message to UI
    /// </summary>
    public void SendMessageUI()
    {
        SendMessageUI("?????");
    }


}
