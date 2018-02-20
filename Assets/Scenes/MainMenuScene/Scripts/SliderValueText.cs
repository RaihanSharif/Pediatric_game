//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
	public string formatText;
	public static float ageValue;
	public static Text tmproText;


	private void Start()
	{
		tmproText = GetComponent<Text>();
		GetComponentInParent<Slider>().onValueChanged.AddListener(HandleValueChanged);
	}

	private void HandleValueChanged(float value)
	{
		tmproText.text = string.Format(formatText, value);
		ageValue = value;
	}


	public void displayAge(){
		GetComponentInParent<Slider> ().enabled = false;

	}
		
}