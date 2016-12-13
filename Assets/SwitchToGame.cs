using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchToGame : MonoBehaviour {

	public int scene;

	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("Launching scene " + scene);
		SceneManager.LoadScene ("game_" + scene);
	}
}
