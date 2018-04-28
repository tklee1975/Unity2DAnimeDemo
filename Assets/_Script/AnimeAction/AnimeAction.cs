using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeAction {
	public string name = "";
	protected bool mIsDone = false;
	protected bool mIsStarted = false;

	protected float mDuration = 0;		// duration = 0  mean instant action 
	protected float mTimeElapse = 0;	// used tell whether need to echo or not 

	protected float mDeltaTime;

	protected AnimeActionManager mManager;

	public void SetManager(AnimeActionManager _manager) {
		mManager = _manager;
	}

	public void StartAction(AnimeAction action) {
		if(mManager != null) {
			Debug.Log("ERROR: AnimeAction: queue action=" + action.name);
			mManager.QueueNewAction(action);
		} else {
			Debug.Log("ERROR: AnimeActionManager: manager is null");
		}
	}


	public virtual void Start() {
		mIsDone = false;	
		mIsStarted = true;
		mTimeElapse = 0;	

		Debug.Log("AnimeAction [" + name + "] started");
		OnStart();		// something the action will be done at 'OnStart'				
	}

	public virtual void Reset() {
		mIsStarted = false;
		mIsDone = false;	
		mTimeElapse = 0;	
	}

	public virtual void Update(float deltaTime) {
		mDeltaTime = deltaTime;
		mTimeElapse += mDeltaTime;

		if(CheckAndReduceTime()) {
			MarkAsDone();
		}

		OnUpdate();
	}
	
	public virtual void Step() {
		
	}

	public virtual bool IsStarted() {
		return mIsStarted;
	}

	public virtual bool IsDone() {
		return mIsDone;
	}

	protected virtual void OnUpdate() {
		// For extension
	}

	protected virtual void OnStart() {
		// For extension
	}

	protected virtual void OnDone() {
		// For extension
	}

	protected void SetEndByCondition() {
		SetDuration(-1);
	}

	protected void MarkAsDone() {
		 if(mIsDone) {
            return;
        }

		OnDone();
		mIsDone = true;
		mIsStarted = false;
		Debug.Log("AnimeAction [" + name + "] done");
	}

	#region Duration Logic Action 
	public void SetDuration(float _duration) {
		mDuration = _duration;
	}

	protected bool CheckAndReduceTime() {	// return: istimeUp
		if(mDuration <= -1) {
			return false;		// e
		}

		if(mTimeElapse >= mDuration) {
			return true;
		}

		return false;
	}


	public float GetTimeElapsed() {
		return mTimeElapse;
	}

	public float GetTimeElapsedRatio() {
		if(mDuration <= 0) {
			return 0;
		}

		return mTimeElapse / mDuration;
	}




	#endregion
}
