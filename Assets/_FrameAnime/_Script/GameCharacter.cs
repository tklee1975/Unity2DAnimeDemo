using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour {

	public enum AnimeAction {
		Idle = 0,
		Attack = 1, 
		CastMagic = 2,
		Hit = 3,
	};

	// Internal Data 
	private Animator mAnimator;

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


	// Note:
	//		https://answers.unity.com/questions/1039227/play-an-animation-of-animator-once-only.html
	public void ChangeAnimeAction(AnimeAction action) {
		if(action == AnimeAction.Idle) {
			mAnimator.SetTrigger("Idle");
		}else if(action == AnimeAction.Attack) {
			mAnimator.SetTrigger("Attack");
		}else if(action == AnimeAction.CastMagic) {
			mAnimator.SetTrigger("Cast");
		}else if(action == AnimeAction.Hit) {
			mAnimator.SetTrigger("Hit");
		}
		//mAnimator.
	}
}
