using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTextImporter : GenericTextImporter {

	protected void Start () {

        //Check for a valid text file

        base.Start();

        if(textFile != null && nextDialogButton != null && dialogBox != null)
        {

            nextDialogButton.onClick.AddListener(PopUpNextLine);
            dialogBox.SetActive(false);
        }

    }

    /***Increments Currentline, thusly scrolling through a supplied dialog text file
     */

    protected void Update()
    {
        //Check and assign text on every frame refresh
        if(endLine != -1 && textBox != null && textFile != null)
        {
            textBox.text = textLines[currentLine];
        }
    }
}
