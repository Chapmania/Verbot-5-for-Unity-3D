using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.UI;
using Conversive.Verbot5;

public class Exemple3 : MonoBehaviour {

    private VerbotScriptTemplate verbot = new VerbotScriptTemplate();

    /// <summary>
    /// Enter the .VKB file path in the StreamingAssets folder
    /// </summary>
    public InputField inputPath;

	// Use this for initialization
	void Start () {
        inputPath.text = "MyFileNameCKB";
        verbot.StartVerbot();

        //Remember that you can only compile one *.VKB at a time.
        string[] PathToVKB = new string[] {
            Path.Combine(Application.streamingAssetsPath,@"Verbots\Sylvie.vkb")
        };
        verbot.LoadKnowledgeBase(PathToVKB);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Remember that you can only compile one *.VKB at a time.
    /// </summary>
    public void SaveCompiledKnowledgeBase()
    {
        verbot.SaveCurrentCompiledKnowledgeBase("Verbots", string.Format("{0}.ckb", inputPath.text));
        inputPath.text = "";
    }

    public void GoToMainMenu()
    {
        MainMenu.GoToMainMenu();
    }

}
