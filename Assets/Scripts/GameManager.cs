using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

	// Use this for initialization
	void Awake()
	{
		FileManager.Instance.GenerateGame ();	
	}

	public void CheckAnswer(AnswerRow value)
	{
		if (value.description.text.Equals (FileManager.Instance.GetAnswers () [Globals.value]))
			Debug.Log ("MUY BIEN");
		else
			Debug.Log ("HAS FALLADO");
	}
}
