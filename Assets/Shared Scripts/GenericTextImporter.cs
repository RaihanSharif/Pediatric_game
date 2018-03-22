using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenericTextImporter : MonoBehaviour {

    //Reference to the text file in Unity inspector
    [SerializeField]
    protected TextAsset textFile;

    //Array to load dialogue lines into
    protected string[] textLines;
   
    //Indices to keep track of line indes
    protected int currentLine = 0;
    protected int endLine = -1;

    //Reference to the component in the scene. Drag an drop from inspector
    [SerializeField]
    protected Text textBox;

    [SerializeField]
    protected Button nextDialogButton;
    
    [SerializeField]
    protected GameObject dialogBox;
	
	protected void Start() {

        //Check for a valid text file
       
        if(textFile != null && textBox != null)
        {
            //Create an array of dialog strings from a supplied newline-seperated text file
            textLines = (textFile.text.Split('\n'));
            endLine = textLines.Length;

        }

    }


    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          SimpleNextLine();
        }
            
        //Check and assign text on every frame refresh
        CheckAssignOnRefresh();
        
    }

    protected void SimpleNextLine(){

         currentLine++;
            if (currentLine >= endLine && endLine != -1)
            {
                textBox.text = textLines[endLine-1];
            }
    }

    protected void PopUpNextLine(){
        
        currentLine++;
        if (currentLine >= endLine && endLine != -1)
        {
            currentLine = 0;
            dialogBox.SetActive(true);
            nextDialogButton.gameObject.SetActive(false);
        }
    }

    protected void CheckAssignOnRefresh(){
        if (endLine != -1 && textBox != null && textFile != null && currentLine < endLine)
        {
            textBox.text = textLines[currentLine];
            
        }
    }
}