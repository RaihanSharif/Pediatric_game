using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaitingTextImporterReception : MonoBehaviour {


    public TextAsset textFile;
    public string[] textLines;
    //public TextAsset waitingTextFile;

    private int currentLine = 0;
    private int endLine = -1;

    private Text TextBox;
    public const string DIALOGUEFINISHED = "ARE YOU READY FOR NEW ADVENTURES?";

	// Update is called once per frame
	void Start () {

        //Check for a valid text file

        
        if(textFile != null)
        {
            //Create an array of dialog strings from a supplied newline-seperated text file
            textLines = (textFile.text.Split('\n'));
            endLine = textLines.Length;

            //Assign TextBox to the text component of this game object and assign nextDialogButton to a child button and give it a on click action listener
            TextBox = this.gameObject.GetComponent<Text>();
        }

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            if (currentLine >= endLine && endLine != -1)
            {
                //currentLine = 0;
                TextBox.text = DIALOGUEFINISHED;
            }
        }
            
        //Check and assign text on every frame refresh
        if (endLine != -1 && TextBox != null && textFile != null && currentLine < endLine)
        {
            TextBox.text = textLines[currentLine];
            
        }
    }
}
