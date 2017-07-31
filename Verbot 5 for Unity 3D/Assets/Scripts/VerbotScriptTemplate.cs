using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
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


    bool FileExist(string path)
    {
        bool fileExist = File.Exists(path);

        if (fileExist == false) {
            Debug.LogError("File does not exist: "+ path);
        }

        return fileExist;
    }

    /// <summary>
    /// Save current knowledge base to a compiled knowledge file *.CKB
    /// You must call the "LoadKnowledgBase()" function first.
    /// Remember that you can only compile one * .VKB at a time.
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

    /// <summary>
    /// Saves the last conversation variables. (Name, etc...)
    /// </summary>
    /// <param name="path">StreamingAssets/.../verbot</param>
    /// <param name="file">nameBIN</param>
    public void SaveVars(string path, string file)
    {
        string sPath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
        string pathToFile = System.IO.Path.Combine(sPath, file);

        this.state.SaveVars(pathToFile);
        Debug.Log("Variables saved");
    }


    /// <summary>
    /// Loads the last conversation variables. (Name, etc...)
    /// </summary>
    /// <param name="path">StreamingAssets/.../verbot</param>
    /// <param name="file">nameBIN</param>
    public void LoadVars(string path, string file)
    {
        string sPath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
        string pathToFile = System.IO.Path.Combine(sPath, file);

        this.state.LoadVars(pathToFile);
        Debug.Log("Variables loaded");
    }

    #endregion


    #region Load Knowledge Base

    /// <summary>
    /// Load the Verbot knowledge base *.VKB
    /// </summary>
    /// <param name="paths">StreamingAssets/.../...</param>
    public void LoadKnowledgeBase(string [] paths)
    {
        // Clears the values of the variables.
        this.state.CurrentKBs.Clear();

        // Get all paths in the array.
        foreach (string path in paths)
        {
            if (FileExist(path) == true)
            {
                //Load a knowledge base.
                kb = verbot.LoadKnowledgeBase(path);

                //Load the knowledgebase item.
                kbi.Filename = Path.GetFileName(path);
                kbi.Fullpath = Path.GetDirectoryName(path) + @"\";

                //Set the knowledge base for verbot.
                verbot.AddKnowledgeBase(kb, kbi);
                this.state.CurrentKBs.Add(path);
            }
        }
    }

    /// <summary>
    /// Load the compiled Verbot knowledge base *.CKB
    /// </summary>
    /// <param name="paths">StreamingAssets/.../...</param>
    public void LoadCompiledKnowledgeBase(string[] paths)
    {
        // Clears the values of the variables.
        this.state.CurrentKBs.Clear();

        // Get all paths in the array.
        foreach (string path in paths)
        {
            if (FileExist(path) == true)
            {
                //Set the knowledge base for verbot.
                this.verbot.AddCompiledKnowledgeBase(path);
                this.state.CurrentKBs.Add(path);
            }
        }
    }
    
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
