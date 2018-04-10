using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHitEvent : MonoBehaviour {
	public GameCharacter targetCharacter;
	public int damageValue = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnHit() {
		if(targetCharacter != null) {
			targetCharacter.GetHit(damageValue);
		}
	}
}
