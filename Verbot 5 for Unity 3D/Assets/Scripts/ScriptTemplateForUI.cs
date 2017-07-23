using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScriptTemplateForUI : MonoBehaviour {

    public Text chatTextUI;
    public InputField userInput;

	
	// Update is called once per frame
	void Update () {
        
    }

    /// <summary>
    /// Send a message to UI
    /// </summary>
    /// <param name="botOutput"></param>
    public void SendMessageUI(string botOutput)
    {
        //https://docs.unity3d.com/Manual/StyledText.html
        chatTextUI.text += string.Format("<b>User</b>: {0}\n<b>Bot</b>: {1}\n\n", userInput.text, botOutput);
        userInput.text = "";
    }

}
