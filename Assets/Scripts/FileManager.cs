using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FileManager : MonoBehaviour {

	private const string PATH = "Files/";

	private const string MONKEY_ISLAND = "Monkey_Island";

	private static FileManager instance = null;

	private string[] questions;
	private string[] answers;

	public static FileManager Instance
	{
		get {return instance;}
	}


	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			DestroyObject (gameObject);
		
		GenerateGame ();
	}

	public void GenerateGame()
	{
		Dictionary<string, string> game = ReadQuestionAndAnswers ();

		questions = new string[game.Count+1];
		answers = new string[questions.Length];
		int x = 0;

		foreach (KeyValuePair<string, string> qa in game) {
			questions [x] = qa.Key;
			answers [x] = qa.Value;
			x++;
		}

		int value = Random.Range (0, questions.Length-1);
		Globals.value = value;

		if (Globals.isDebug) {
			Debug.Log ("Position array: " + value);
			Debug.Log ("QUESTION: -> " + questions [value]);
			foreach (string answer in GetAnswers())
				Debug.Log ("\t\t" + answer);
			Debug.Log ("CORRECT: -> " + answers [value]);
		}
	}

	private TextAsset ReadFile(string name)
	{
		return Resources.Load<TextAsset> (PATH + name);
	}

	public string[] ReadFileByLines(string name)
	{
		return ReadFile(name).text.Split('\n');
	}

	public Dictionary<string,string> ReadQuestionAndAnswers()
	{
		Dictionary<string, string> dic = new Dictionary<string, string>();
		string[] lines = ReadFileByLines (MONKEY_ISLAND);

		for (int x = 0; x < lines.Length-1; x++) {
			dic.Add(lines[x], lines[x+1]);
			x++;

		}
		return dic;
	}

	public string[] GetAnswers()
	{
		return answers;
	}

	public string[] GetQuestions()
	{
		return questions;
	}

}
