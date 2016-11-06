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

		DontDestroyOnLoad (gameObject);

		FileManager.Instance.GenerateGame ();
	}

	public void CheckAnswer(AnswerRow value)
	{
		if (value.description.text.Equals (FileManager.Instance.GetAnswers () [Globals.value]))
			Console.Instance.Write("MUY BIEN");
		else
			Console.Instance.Write ("HAS FALLADO");
	}
}
