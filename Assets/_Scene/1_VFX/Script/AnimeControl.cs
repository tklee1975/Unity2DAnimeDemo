using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeControl : MonoBehaviour {
	private Animation mAnimation;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		mAnimation = GetComponent<Animation>();	
	}

	public void Play() {
		mAnimation.Play();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
