using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTextImporter : GenericTextImporter {

	void Start () {

        //Check for a valid text file

        base.Start();

        if(textFile != null && nextDialogButton != null && dialogBox != null)
        {

            //Assign TextBox to the text component of this game object and assign nextDialogButton to a child button and give it a on click action listener
            //TextBox = this.gameObject.GetComponent<Text>();
            //nextDialogButton = GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>();
            nextDialogButton.onClick.AddListener(PopUpNextLine);
            //dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
            dialogBox.SetActive(false);
        }

    }

    /***Increments Currentline, thusly scrolling through a supplied dialog text file
     */

    void Update()
    {
        //Check and assign text on every frame refresh
        if(endLine != -1 && textBox != null && textFile != null)
        {
            textBox.text = textLines[currentLine];
        }
    }
}
