using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
//Target: Animator have a state d


*/
public class AnimatorAction : AnimeAction {
	public Animator animator;
    public AnimeEvent animeEvent;                   // Auto
    public string triggerState = "";
    public AnimeAction onHitAction = null;
    public float playDuration = -1;                 // default: 

    protected override void OnStart()
    {
        if(animator == null) {
            Debug.Log("ERROR: AnimatorAction missing animator");
            MarkAsDone();
        }
        
        animeEvent = animator.GetComponent<AnimeEvent>();
        if(animeEvent != null) {
            animeEvent.EndCallback = OnAnimeEnd;        // called by end_clip
            animeEvent.Callback = OnAnimeEvent;         // 

            animator.SetTrigger(triggerState);
        }

        SetDuration(playDuration);                  // 

    }

    public override bool IsDone() {
        if(onHitAction != null) {
            if(onHitAction.IsDone() == false) {
                return false;
            }
        }

		return mIsDone;
	}



    protected virtual void OnAnimeEnd() {
        MarkAsDone();
    }

    protected virtual void OnAnimeEvent(string eventName) {
        if(eventName == "hit") {
            if(onHitAction != null) {
                onHitAction.Start();
            }
        }
    }

}