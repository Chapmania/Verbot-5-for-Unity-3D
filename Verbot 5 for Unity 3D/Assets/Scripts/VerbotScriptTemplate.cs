using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Conversive.Verbot5;

/// <summary>
/// Sample that uses the Verbot 5 Library.
/// </summary>
public class VerbotScriptTemplate
{
    //Verbot variables
    private Verbot5Engine verbot;
    private State state;
    private KnowledgeBase kb;
    private KnowledgeBaseItem kbi;

    // Use this for initialization
    public void StartVerbot () {
        this.verbot = new Verbot5Engine();
        this.state = new State();
        kb = new KnowledgeBase();
        kbi = new KnowledgeBaseItem();
        Debug.Log("Verbot initialized");
    }

    #region Useful

    /// <summary>
    /// Save current knowledge base to a compiled knowledge file *.CKB
    /// You must call the "LoadKnowledgBase()" function first
    /// </summary>
    /// <param name="path">StreamingAssets/.../....</param>
    /// <param name="file">Untitled.ckb</param>
    public void SaveCurrentCompiledKnowledgeBase(string path, string file)
    {
        try
        {
            string sPath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
            string pathToSaveFile = System.IO.Path.Combine(sPath, file);

            CompiledKnowledgeBase ckb = verbot.CompileKnowledgeBase(kb, kbi);

            verbot.SaveCompiledKnowledgeBase(ckb, pathToSaveFile);
            Debug.Log(string.Format("{0} file saved in: {1}", file, pathToSaveFile));
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.ToString());
        }
    }

    #endregion


    #region Load Knowledge Base

    /// <summary>
    /// Load the Verbot knowledge base *.VKB
    /// </summary>
    /// <param name="path">StreamingAssets/.../verbot</param>
    /// <param name="file">Untitled.vkb</param>
    public void LoadKnowledgeBase(string path, string file)
    {
        string sPath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
        string pathToFile = System.IO.Path.Combine(sPath, file);

        kb = verbot.LoadKnowledgeBase(pathToFile);

        // load the knowledgebase item
        kbi.Filename = file;
        kbi.Fullpath = sPath + @"\";

        // set the knowledge base for verbot
        verbot.AddKnowledgeBase(kb, kbi);
        this.state.CurrentKBs.Clear();
        this.state.CurrentKBs.Add(pathToFile);
    }

    /*
    public void LoadCompiledKnowledgeBase(string path)
    {
        this.verbot.AddCompiledKnowledgeBase(path);
        this.state.CurrentKBs.Clear();
        this.state.CurrentKBs.Add(path);
    }
    */
    #endregion

    public string getReply(string stInput)
    {
        string output = "";       
        Reply reply = this.verbot.GetReply(stInput, this.state);
        if (reply != null)
        {
            output = reply.Text;
            //this.parseEmbeddedOutputCommands(reply.AgentText);
            //this.runProgram(reply.Cmd);
        }
        else
        {
            output = "No reply found.";
        }

        return output;
    }



}
