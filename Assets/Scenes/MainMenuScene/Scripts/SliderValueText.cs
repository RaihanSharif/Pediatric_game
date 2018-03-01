//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
	public string formatText; // string value of the age
	public static float ageValue; // age value when the age slider is updated
	public static Text tmproText;


	private void Start()
	{
		tmproText = GetComponent<Text>();
		GetComponentInParent<Slider>().onValueChanged.AddListener(HandleValueChanged); // add listener to slider 
	}
	/// <summary>
	/// Handles the value changed.
	/// </summary>
	/// <param name="value">Value.</param>
	private void HandleValueChanged(float value)
	{
		tmproText.text = string.Format(formatText, value); // convert the string value of age into an integer
		ageValue = value; // update the ageValue variable 
	}

	/// <summary>
	/// Displaies the age and prevents the user from changing the slider value again.
	/// </summary>
	public void displayAge(){
		GetComponentInParent<Slider> ().enabled = false;

	}
		
}