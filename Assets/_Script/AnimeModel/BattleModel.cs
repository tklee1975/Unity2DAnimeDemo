using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModel : MonoBehaviour {
	public enum Dir {
		Left,
		Right,
	};

	public float moveDuration = 0.3f;
	public Dir faceDir = Dir.Left; 

	protected Animator mAnimator;
	protected AnimeEvent mAnimeEvent;
	protected MoveAction mMoveAction;
	protected bool mStartMove = false;

	public delegate void Callback();

	protected Callback mHitCallback;
	protected Callback mEndCallback;

	protected Callback mMoveCallback;
	

	protected Vector3 mOriginPosition;
	protected Vector3 mTargetPosition;

	protected int mDebugCounter;		// For debugging
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		mAnimator = GetComponentInChildren<Animator>();	

		if(mAnimator != null) {
			mAnimeEvent = mAnimator.GetComponent<AnimeEvent>();
		}
		
        if(mAnimeEvent != null) {
            mAnimeEvent.EndCallback = OnAnimeEnd;        // called by end_clip
            mAnimeEvent.Callback = OnAnimeEvent;         // 

            // animator.SetTrigger(triggerState);
        }

		mOriginPosition = (Vector2) transform.position;

		// For Moving 
		mMoveAction = new MoveAction();
		mMoveAction.name = "BattleModel.move";
		mMoveAction.autoFlip = false;
		mMoveAction.targetObject = gameObject;

		mDebugCounter = 0;
	}

	public void ShowMoveAnime() {
		ShowForwardAnime();
	}

	public void ShowForwardAnime() {
		mAnimator.SetTrigger("forward");
	}

	public void ShowBackwardAnime() {
		mAnimator.SetTrigger("backward");
	}

	public void ShowIdleAnime() {
		mAnimator.SetTrigger("idle");
	}

	protected void OnAnimeEvent(string evt) {
		Debug.Log("OnAnimeEvent_" + (mDebugCounter++) + ": " + evt);
		if(evt.ToLower() == "hit") {
			if(mHitCallback != null) {
				mHitCallback();
			}
		}
	}

	protected void OnAnimeEnd() {
		if(mEndCallback != null) {
			mEndCallback();
		}		
	}

	//protected voi

	public void ShowAttackAnime(int style) {
		string stateName;
		if(style == 1) {
			stateName = "skill";
		} else {
			stateName = "attack";
		}
		mAnimator.SetTrigger(stateName);
	}

	public void Move(Vector2 targetPos) {
		ShowMoveAnime();
		MoveTo(targetPos, moveDuration, () => {
			ShowIdleAnime();
		});
	}

	public void Hit(Callback endCallback = null)
	{
		mEndCallback = () => {
			if(endCallback != null) {
				endCallback();
			}
			mEndCallback = null;
		};

		mAnimator.SetTrigger("hit");
	}

	public void Attack(short style, Callback hitCallback = null, Callback endCallback = null)
	{
		mHitCallback = hitCallback;
		mEndCallback = () => {
			Debug.Log("Attack:EndCallback");
			if(endCallback != null) {
				endCallback();
			}
			mEndCallback = null;
			mHitCallback = null;
		};

		ShowAttackAnime(style);
	}

	public void MeleeAttack(Vector2 targetPos, Callback hitCallback = null, Callback endCallback = null) {
		//mOriginPosition = transform.positionVector2;
		mOriginPosition = (Vector2) transform.position;
		mTargetPosition = targetPos;

	// protected Callback mMeleeHitCallback;
	// protected Callback mMeleeEndCallback;

	// public Callback hitCallback;
	// public Callback animeEndCallback;

		// MoveForward(() => {

		// });
		// // 
		// ShowMoveAnime();
		// MoveTo(targetPos, moveDuration, () => {
		// 	ShowAttackAnime();
		// });
	}

	public Vector3 GetHitPosition() {
		float offsetX = -1;
		if(faceDir == Dir.Right) {
			offsetX = -offsetX;
		}
		if(transform.localScale.x < 0) { offsetX *= -1; }
		return transform.position + new Vector3(offsetX, 0, 0);
	}


	public Vector3 GetLaunchPosition() {
		return transform.position + new Vector3(-2, 1, 0);
	}

	public void MoveForward(Vector3 targetPos, Callback callback = null) {
		mTargetPosition = targetPos;
		mOriginPosition = transform.position;
		ShowForwardAnime();
		MoveTo(mTargetPosition, moveDuration, callback);
	}

	public void MoveBack(Callback callback = null) {
		ShowBackwardAnime();
		MoveTo(mOriginPosition, moveDuration, () => {
			//Debug.Log("MoveBack Finished!");
			ShowIdleAnime();
			if(callback != null) {
				callback();
			}
		});
	}
	
	public void MoveTo(Vector3 targetPos, float duration, Callback callback) {
		mMoveAction.Reset();
		mMoveAction.name = "moveTo:" + targetPos;
		mMoveAction.startPosition = transform.position;

		// Vector3 endPos = transform.position;
		// endPos.x = targetPos.x; endPos.y = targetPos.y;
		mMoveAction.endPosition = targetPos;

		mMoveAction.SetDuration(duration);

		mMoveCallback = callback;
		mMoveAction.Start();
		mStartMove = true;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove();	
	}

	void UpdateMove() {
		if(mStartMove == false) {
			return;
		} 
		mMoveAction.Update(Time.deltaTime);
		if(mMoveAction.IsDone()) {
			Debug.Log("UpdateMove: " + mMoveAction.name + " done!");
			mStartMove = false;
			if(mMoveCallback != null) {
				mMoveCallback();
			}
			
		}
	}


	
}
