using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private static GameManager instance;

	public static GameManager Instance
	{ get {return instance; }}


	// Use this for initialization
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			DestroyObject (gameObject);

		DontDestroyOnLoad ();

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
