using UnityEngine;
using System.Collections;

public class noteScript : MonoBehaviour {


	Rigidbody2D rb;
	public float speed;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (0, -speed);
	}
}
