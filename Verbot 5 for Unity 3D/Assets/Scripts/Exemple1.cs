using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Conversive.Verbot5;

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Exemple1 : MonoBehaviour
{
    // verbot variables
    Verbot5Engine verbot = new Verbot5Engine();
    KnowledgeBase kb = new KnowledgeBase();
    KnowledgeBaseItem kbi = new KnowledgeBaseItem();
    State state = new State();

    // Use this for initialization
    void Start()
    {
        // build the knowledgebase
        Rule vRule = new Rule();
        vRule.Id = kb.GetNewRuleId();
        vRule.AddInput("Hello", "");
        vRule.AddInput("Hi", "");
        vRule.AddOutput("Hello, World", "", "");
        kb.Rules.Add(vRule);

        //Path to save the file
        string fileNameVKB = "kbi.vkb";
        string sPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Verbots");
        string fullPath = System.IO.Path.Combine(sPath, fileNameVKB);

        try
        {
            // save the knowledgebase
            XMLToolbox xToolbox = new XMLToolbox(typeof(KnowledgeBase));
            xToolbox.SaveXML(kb, fullPath);
            Debug.Log(string.Format("{0} file saved in: {1}", fileNameVKB, fullPath));
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.ToString());
        }

        // load the knowledgebase item
        kbi.Filename = fileNameVKB;
        kbi.Fullpath = sPath + @"\";

        // set the knowledge base for verbot
        verbot.AddKnowledgeBase(kb, kbi);

        state.CurrentKBs.Add(fullPath);

        //Console: bot Response 
        Debug.Log("Verbot initialized");
        string userInput = "Hello";
        Debug.Log(string.Format("User: {0}", userInput));
        Debug.Log(string.Format("Bot: {0}", getReply(userInput)));
    }

    public string getReply(string stInput)
    {
        string output = string.Empty;

        // process the reply
        Reply reply = verbot.GetReply(stInput, state);
        if (reply != null)
        {
            output = reply.AgentText;
        }
        else
        {
            output = "No reply found.";
        }

        return output;
    }


    public void GoToMainMenu()
    {
        MainMenu.GoToMainMenu();
    }

}
