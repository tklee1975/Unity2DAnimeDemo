using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour {

	private Animator mAnimator = null;
	
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{	
		mAnimator = GetComponentInChildren<Animator>();
 	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	#region  VFX Play 
	public void Play() {
		mAnimator.SetTrigger("Active");
	}

	#endregion


	#region  OnHit Handling 
	
	public GameCharacter targetCharacter;
	public int hitDamage;


	public void OnHit() {
		if(targetCharacter != null) {
			targetCharacter.GetHit(hitDamage);
		}
	}

	#endregion
}
