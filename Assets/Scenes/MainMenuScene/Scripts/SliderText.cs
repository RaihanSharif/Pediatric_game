using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {

	Text textComponent;

	void Start() {
		textComponent = GetComponent<Text>();
	}

	public void SetSliderValue(float sliderValue) {
		textComponent.text = Mathf.Round(sliderValue * 10).ToString();
	}


}
