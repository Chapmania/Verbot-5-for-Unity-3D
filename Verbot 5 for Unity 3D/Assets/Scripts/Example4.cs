using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example4 : ScriptTemplateForUI
{
    private VerbotScriptTemplate verbot = new VerbotScriptTemplate();

    // Use this for initialization
    void Start()
    {
        chatTextUI.text = "";
        verbot.StartVerbot();
        verbot.LoadCompiledKnowledgeBase("Verbots", "MyFileNameCKB.ckb");
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
