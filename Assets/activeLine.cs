using UnityEngine;
using System.Collections;

public class activeLine : MonoBehaviour {


	AudioSource source;
	SpriteRenderer sprite;
	public KeyCode key;
	public float fadeTime;
	bool active = false;
	GameObject note;
	Color color;
	Color colorAlpha;
	bool pressed = false;



	void Awake () {
		sprite = GetComponent<SpriteRenderer> ();
		source = GetComponent<AudioSource> ();
		color = GetComponent<SpriteRenderer>().color;
		colorAlpha = color;
		colorAlpha.a = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key) && active) 
		{
			Destroy(note);
			AddScore ();
			active = false;

		}
		if (Input.GetKeyDown (key)) 
		{
			sprite.color = colorAlpha;
			source.Stop();
			source.volume = 1f;
			source.Play();
			pressed = true;
		}
		if (Input.GetKeyUp (key))
		{
			sprite.color = color;
			//source.Stop ();
			pressed = false;
			StartCoroutine(fadeOut());
			StartCoroutine(ExecuteAfterTime(1.5f));

		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		active = true;


		if (col.gameObject.tag == "note") 
		{
			note = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		active = false;
	}

	void AddScore()
	{
		PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") + 100);
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		if (Input.GetKeyDown (key)) {
			
		} else {
			source.Stop();
			source.volume = 1f;
		}
	}


	IEnumerator fadeOut()
	{
		for (int i = 50; i > 0; i--) 
		{
			if (!pressed) {
				source.volume -= 0.02f;
				yield return new WaitForSeconds (0.01f);
			}
		}

	}



}
