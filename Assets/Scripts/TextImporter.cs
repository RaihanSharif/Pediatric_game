using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {


    public TextAsset textFile;
    public string[] textLines;

    private int currentLine = 0;
    private int endLine = -1;

    private Text TextBox;
    private Button nextDialogButton;
    private GameObject dialogBox;

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
            nextDialogButton = GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>();
            nextDialogButton.onClick.AddListener(nextText);
            dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
            dialogBox.SetActive(false);
        }

    }

    /***Increments Currentline, thusly scrolling through a supplied dialog text file
     */
    void nextText()
    {
        currentLine++;
        if (currentLine >= endLine && endLine != -1)
        {
            currentLine = 0;
            dialogBox.SetActive(true);
            nextDialogButton.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //Check and assign text on every frame refresh
        if(endLine != -1 && TextBox != null && textFile != null)
        {
            TextBox.text = textLines[currentLine];
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
