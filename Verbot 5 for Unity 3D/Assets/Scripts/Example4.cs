using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class Example4 : ScriptTemplateForUI
{
    private VerbotScriptTemplate verbot = new VerbotScriptTemplate();

    // Use this for initialization
    void Start()
    {
        chatTextUI.text = "";
        verbot.StartVerbot();
        string[] PathToCKBs = new string[] {
            Path.Combine(Application.streamingAssetsPath,@"Verbots\MyFileNameCKB.ckb")
        };
        verbot.LoadCompiledKnowledgeBase(PathToCKBs);

        //Load Brain/memoirs
        verbot.LoadVars("Verbots", "memoirs.dat");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        //Save Brain/memoirs
        verbot.SaveVars("Verbots", "memoirs.dat");
    }


    /// <summary>
    /// /// Send a message to UI
    /// </summary>
    public void SendMessageUI()
    {
        SendMessageUI(verbot.getReply(userInput.text));
    }

}
