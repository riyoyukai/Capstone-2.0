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
	public InputField dayField;
	public InputField yearField;
	public Text ampmField;
	public Text monthText;
	public GameObject monthOptions;
	public GameObject ampmOptions;
	
	private int remindMinutes;
	private int remindHours;
	private int remindDays;
	private int remindWeeks;
	private int remindYears;

	void Start(){
		day = (System.DateTime.Today.Day);
		E_EnterMonth(System.DateTime.Today.Month);
		year = System.DateTime.Today.Year;
		hour = System.DateTime.Now.Hour;
		minute = System.DateTime.Now.Minute;

		hour++;
		if (hour == 24) {
			hour = 0;
			day++;
			if(day > System.DateTime.DaysInMonth(year, month)){
				day = 1;
				month++;
				if(month == 13){
					month = 1;
					year++;
				}
			}
		}
		
		hourField.text = "" + hour;
		if(hour == 0) hourField.text = "" + 12;
		if(hour > 12) hourField.text = "" + (hour-12);
		minuteField.text = "" + minute;
		yearField.text = "" + year;
		dayField.text = "" + day;
		
		ampm = "AM";
		if(hour > 12) ampm = "PM";
		ampmField.text = ampm;

		BuildDeadlineText ();
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
		month = monthInt;
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
	
	public void E_EnterDay(){
		day = int.Parse(dayField.text);
		int daysInMo = System.DateTime.DaysInMonth (year, month);
		if (day > daysInMo) {
			day = daysInMo;
		}
		//TODO: Test to see if days are properly limited

		dayField.text = "" + day;

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
	
	public void E_RemindMinutes(){
		
	}
	
	public void E_RemindHours(){
		
	}
	
	public void E_RemindDays(){
		
	}
	
	public void E_RemindWeeks(){
		
	}
	
	public void E_RemindMonths(){
		
	}

	public void E_Confirm(){
		System.DateTime deadlineDate = new System.DateTime (year, month, day, hour, minute, 0);
		print ("DEADLINE: " + deadlineDate);
		//TODO: build date and compare to today. if in the past, give error.
		print ("Comparing: " + System.DateTime.Compare (deadlineDate, System.DateTime.Now));
		// if -1, invalid
	}
}
