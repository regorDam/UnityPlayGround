using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Question : MonoBehaviour {

	[SerializeField]
	private Text question;

	void Awake () 
	{
		question = GetComponentInChildren<Text> ();


	
	}

	void Start()
	{
		question.text = FileManager.Instance.GetQuestions () [Globals.value];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
