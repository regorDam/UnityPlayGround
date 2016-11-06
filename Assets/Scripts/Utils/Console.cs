using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {

	private static Console instance = null;

	public static Console Instance{ get {return instance; } }

	public Text line;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			DestroyObject (gameObject);

		line = GetComponentInChildren<Text> ();
	}

	public void Write(string msg)
	{
		line.text = msg;
	}



}
