//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
    //  formatter to add 'years' after the age number 
    public string sliderTextFormatter;
	public static float ageValue;

    // age display text field object 
	public static Text ageSliderText;

    /// <summary>
    /// binds the Unity textfield componenet to the ageSliderText variable 
    /// then adds a listener to the handle, the listener is the handle value change method. 
    /// </summary>
	private void Start()
	{
		ageSliderText = GetComponent<Text>();
		GetComponentInParent<Slider>().onValueChanged.AddListener(HandleValueChanged);
	}

    /// <summary>
    /// formats the string to be displayed in the textfield with the formatter and 
    /// then updates the ageValue variable 
    /// </summary>
    /// <param name="value"></param>
	private void HandleValueChanged(float value)
	{
		ageSliderText.text = string.Format(sliderTextFormatter, value);
		ageValue = value;
	}

    /// <summary>
    /// changes the value of the slider text  
    /// </summary>
	public void displayAge(){
		GetComponentInParent<Slider> ().enabled = false;
	}

		
}