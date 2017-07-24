using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Sample application that uses the Verbot 5 Library.
/// </summary>
public class Exemple2 : ScriptTemplateForUI
{

    private VerbotScriptTemplate verbot = new VerbotScriptTemplate();

    // Use this for initialization
    void Start()
    {
        chatTextUI.text = "";
        verbot.StartVerbot();
        verbot.LoadKnowledgeBase("Verbots", "julia.vkb");
        //
       
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
        SendMessageUI(verbot.getReply(userInput.text));
    }


}
