using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngestionTextImporter : MonoBehaviour
{
    private TextAsset textFile;
    public string[] textLines;
    public TextAsset IngestionKidTextFile;

    private int currentLine = 0;
    private int endLine = -1;

    private Text TextBox;
    private Button nextDialogButton;
    private GameObject dialogBox;
    
    private int procedureSelected = 1; //0 = Failed selection, 1 = Ingestion Dialog

    
    void Start()
    {
        //Check for a valid text file
        switch (procedureSelected)
        {
            case 0:
                textFile = null;
                break;

            case 1:
                textFile = IngestionKidTextFile;
                break;


        }
        if (textFile != null)
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
        if (endLine != -1 && TextBox != null && textFile != null)
        {
            TextBox.text = textLines[currentLine];
        }
    }
}
