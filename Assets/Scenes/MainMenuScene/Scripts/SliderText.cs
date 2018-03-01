using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {

	Text textComponent;

	void Start() {
		textComponent = GetComponent<Text>();
	}

	/// <summary>
	/// update slider value when the slider is dragged from left to right 
	/// </summary>
	/// <param name="sliderValue">Slider value.</param>
	public void SetSliderValue(float sliderValue) {
		textComponent.text = Mathf.Round(sliderValue * 10).ToString();
	}


}
