using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item 
{
	public string name;
	public string wave;
	public string score;

}

public class CreateScrollList : MonoBehaviour 
{
	public GameObject sampleRow;
	public List<Item> itemList;

	public bool readFile;

	public Transform contentPanel;

	private FileManager fileManager;

	void Start () 
	{
		fileManager = FileManager.Instance;

		if (readFile)
			PopulateListFromFile ();
		else 
			PopulateList ();
	}


	void PopulateList()
	{
		foreach (var item in itemList) 
		{
			GameObject newRow = Instantiate(sampleRow) as GameObject;
			newRow.transform.SetParent(contentPanel, false);
			SampleRow row = newRow.GetComponent<SampleRow>();
			row.nameLabel.text = item.name;
			row.waveLabel.text = item.wave;
			row.scoreLabel.text = item.score;

		}
	}

	void PopulateListFromFile()
	{
		int length = fileManager.GetAnswers ().Length;
		string[] items = new string[length];
		System.Array.Copy (fileManager.GetAnswers (), items, length);

		foreach (var item in items) 
		{
			GameObject newRow = Instantiate(sampleRow) as GameObject;
			newRow.transform.SetParent(contentPanel, false);
			AnswerRow row = newRow.GetComponent<AnswerRow>();
			row.description.text = item;	
		}
	}
		
}
