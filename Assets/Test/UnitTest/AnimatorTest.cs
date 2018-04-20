using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AnimatorTest : BaseTest {
	public Animator animator;
	public AnimeEvent animeEvent;


	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Debug.Log("Setting EndCallback handling");
		animeEvent.EndCallback = () => {
			Debug.Log("Animation End");
		};
	}

	[Test]
	public void ClipInfo() {
		//public AnimationInfo[] GetCurrentAnimationClipState(int layerIndex);


		AnimationClip[] clipList = animator.runtimeAnimatorController.animationClips;
		Debug.Log("clipList size=" + clipList.Length);
		foreach(AnimationClip clip in clipList) {
			Debug.Log("Animation Clip=" + clip);
		}
	}

	public void EndClipEvent(string clipName) 
    {
		Debug.Log("AnimationClip: " + clipName + " reach end");
        //print("PrintEvent: " + i + " called at: " + Time.time);
    }

	//https://docs.unity3d.com/ScriptReference/AnimationEvent.html
	[Test]
	public void SetupEndClipEvent() {
		//public AnimationInfo[] GetCurrentAnimationClipState(int layerIndex);

		AnimationClip[] clipList = animator.runtimeAnimatorController.animationClips;
		Debug.Log("clipList size=" + clipList.Length);
		foreach(AnimationClip clip in clipList) {
			AnimationEvent evt = new AnimationEvent();
			evt.stringParameter = clip.name;
			evt.functionName = "EndClipEvent";
			evt.time = clip.length - 0.1f;
			Debug.Log("Animation Event=" + evt);
			clip.AddEvent(evt);
			//Debug.Log("Animation Clip=" + clip);
		}
	}

	[Test]
	public void testFire()
	{
		//Debug.Log("###### TEST 1 ######");
		animator.SetTrigger("fire");
		//animator.GetCurrentAnimatorClipInfo();
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
