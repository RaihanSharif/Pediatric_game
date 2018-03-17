using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenericTextImporter : MonoBehaviour {

    //Reference to the text file in Unity inspector
    [SerializeField]
    private TextAsset textFile;

    //Array to load dialogue lines into
    private string[] textLines;
   
    //Indices to keep track of line indes
    private int currentLine = 0;
    private int endLine = -1;

    //Reference to the component in the scene. Drag an drop from inspector
    [SerializeField]
    private Text textBox;
	
	void Start() {

        //Check for a valid text file
       
        if(textFile != null && textBox != null)
        {
            //Create an array of dialog strings from a supplied newline-seperated text file
            textLines = (textFile.text.Split('\n'));
            endLine = textLines.Length;

        }

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            if (currentLine >= endLine && endLine != -1)
            {

                textBox.text = textLines[endLine-1];
            }
        }
            
        //Check and assign text on every frame refresh
        if (endLine != -1 && textBox != null && textFile != null && currentLine < endLine)
        {
            textBox.text = textLines[currentLine];
            
        }
    }
}