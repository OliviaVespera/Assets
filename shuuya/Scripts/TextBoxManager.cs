using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text mText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine; 
	public int endAtLine;

	public bool isActive;
	public bool stopPlayerMovement;

	public AgentTestScript player;
	
	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines=(textFile.text.Split('\n'));
		}

		if (endAtLine == 0) {
			endAtLine=textLines.Length-1;
		}

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive) {
			return;
		}

		mText.text = textLines [currentLine];
		if (Input.GetMouseButtonDown(0)) {
			currentLine+=1;
		}
		if (currentLine > endAtLine) {
			DisableTextBox();
		}
	
	}

	public void EnableTextBox()
	{
		textBox.SetActive (true);
		if (stopPlayerMovement) {
			player.canMove=false;
		}
	}
	public void DisableTextBox()
	{
		textBox.SetActive (false);
		player.canMove = true;
	}
}
