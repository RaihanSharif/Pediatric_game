using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcedureTextImporter : PopupTextImporter {

    //References to the different text files to choose from
    //Drag and drop from Unity inspector.
    public TextAsset kidInjectionFile;
    public TextAsset kidIngestionFile;
    public TextAsset babyIngestionFile;


	void Start () {

        //Get the chosen scene from main menu
        var choice = EventManager.chosenScene;

        //This is here only to check if the script works
        //The script otherwise won't work if not played from main menu
        //choice = "CremeApplication";

        //Load the appropriate text file
        switch (choice)
        {
            case "":
                textFile = null;
                break;

            case "CremeApplication":
                textFile = kidInjectionFile;
                break;
  
            case "IngestionBaby":

                textFile = babyIngestionFile;
                break;

            case "IngestionKid":
                textFile = kidIngestionFile;
                break;


        }
        //Call superclass method
       base.Start();

    }

    /***Increments Currentline, thus scrolling through a supplied dialog text file
     */

    void Update()
    {
        //Call superclass method
        base.Update();
    }
}
