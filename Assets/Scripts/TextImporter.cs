using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {


    public TextAsset textFile;
    public string[] textLines;

	// Update is called once per frame
	void Update () {
		
        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
	}
}
