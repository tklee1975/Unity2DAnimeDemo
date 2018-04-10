using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEvent : MonoBehaviour {
	public Animator targetAnimator = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnHit() {
		if(targetAnimator != null) {
			targetAnimator.SetTrigger("Hit");
		}
	}
}
