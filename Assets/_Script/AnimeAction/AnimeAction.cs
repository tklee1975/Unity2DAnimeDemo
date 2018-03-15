using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeAction {
	protected bool mIsDone = false;

	public virtual void Start() {
		mIsDone = true;	
	}
	
	public virtual void Step() {
		
	}

	public virtual bool IsDone() {
		return mIsDone;
	}

	protected virtual void OnDone() {

	}

	protected void MarkAsDone() {
		OnDone();
		mIsDone = true;
	}
}
