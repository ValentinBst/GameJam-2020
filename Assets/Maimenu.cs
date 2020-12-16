using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour
{
	public void doquit() {
		Debug.Log("has quit game");
		Application.Quit();
	}

}

