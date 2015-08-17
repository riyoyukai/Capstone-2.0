using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadlineController : MonoBehaviour {
	
	private int month;
	private string monthString;
	private int day;
	private int year;
	private int hour;
	private int minute;
	private string ampm;

	public Text deadlineText;

	public InputField hourField;
	public InputField minuteField;
	public InputField yearField;
	public Text ampmField;
	public Text monthText; // used for styling
	public GameObject monthOptions;
	public Text dayText; // used for styling
	public GameObject dayOptions;
	public GameObject ampmOptions;

	private static float fcn = 50.0f / 255.0f;

	void Start(){
		E_EnterDay(System.DateTime.Today.Day);
		E_EnterMonth(System.DateTime.Today.Month);
		year = System.DateTime.Today.Year;
		hour = System.DateTime.Now.Hour;
		minute = System.DateTime.Now.Minute;
		ampm = "AM";
		hourField.text = "" + hour;
		if(hour == 0) hourField.text = "" + 12;
		if(hour > 12) hourField.text = "" + (hour-12);
		minuteField.text = "" + minute;
		yearField.text = "" + year;

		if(hour > 12) ampm = "PM";
		ampmField.text = ampm;

		BuildDeadlineText ();

		print (hour);
	}

	private void BuildDeadlineText(){
		int hhInt = hour;
		if(hhInt > 12) hhInt -= 12;
		if(hhInt == 0) hhInt = 12;
		string hh = "" + (hhInt);
		string mm = "" + minute;
		if (minute < 10) mm = "0" + mm;
		deadlineText.text = monthString + " " + day + ", " + year + " at " + hh + ":" + mm + " " + ampm;
	}
	
	public void E_EnterMonth(int monthInt){
		monthString = "ERROR";
		switch (monthInt) {
			case 1: monthString = "January"; break;
			case 2: monthString = "February"; break;
			case 3: monthString = "March"; break;
			case 4: monthString = "April"; break;
			case 5: monthString = "May"; break;
			case 6: monthString = "June"; break;
			case 7: monthString = "July"; break;
			case 8: monthString = "August"; break;
			case 9: monthString = "September"; break;
			case 10: monthString = "October"; break;
			case 11: monthString = "November"; break;
			case 12: monthString = "December"; break;
		}
		monthText.text = monthString;
		monthOptions.SetActive (false);
		BuildDeadlineText ();
	}
	
	public void E_EnterDay(int dayInt){
		dayText.text = "" + dayInt;
		dayOptions.SetActive (false);
		day = dayInt;
		BuildDeadlineText ();
	}
	
	public void E_EnterYear(){
		year = int.Parse(yearField.text);
		BuildDeadlineText ();
	}
	
	public void E_EnterHour(){
		int.TryParse (hourField.text, out hour);
		if(hour > 12){
			hour = 12;
			hourField.text = "" + 12;
		}
		if(hour < 1){
			hour = 1;
			hourField.text = "" + 1;
		}

		if (hour == 12 && ampm == "AM") hour = 0;
		if (ampm == "PM") {
			hour += 12;
		}
		BuildDeadlineText ();
	}
	
	public void E_EnterMinute(){
		print ("Enter minute done");
		int.TryParse (minuteField.text, out minute);
		if(minute > 59){
			minute = 59;
			minuteField.text = "" + 59;
		}
		if(minute < 10) minuteField.text = "0" + minute;
		BuildDeadlineText ();
	}
	
	public void E_EnterAMPM(string ampmString){
		ampm = ampmString;
		if (ampm == "PM") {
			if(hour < 13) hour += 12;
		}
		ampmField.text = ampm;
		ampmOptions.SetActive (false);
		BuildDeadlineText ();
	}
	
	public void E_PreventNegatives(InputField inpField){
		if(inpField.text.Contains("-")){
			inpField.text = inpField.text.Replace("-", "");
		}
	}

	public void E_Confirm(){
		//TODO: build date and compare to today. if in the past, give error.
	}
}
