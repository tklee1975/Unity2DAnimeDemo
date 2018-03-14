using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleVFX : MonoBehaviour {

	
	private Animator mAnimator = null;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{	
		mAnimator = transform.Find("Body").GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(string vfxName) {
		if(mAnimator == null) {
			Debug.Log("BattleVFX: mAnimator is null");
			return;
		}

		mAnimator.SetTrigger(vfxName);
	}
}
