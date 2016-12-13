using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PPText : MonoBehaviour {

	public string name;
	
	void Update () {
		GetComponent<Text> ().text = PlayerPrefs.GetInt (name) + "";
	}
}
