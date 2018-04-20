using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class SimpleAnimationTest : BaseTest {

	public AnimationClip clip1;
	public AnimationClip clip2;

	public SimpleAnimation animation;

	const string kStateName = "Default";


	[Test]
	public void fireVFX()
	{
		
		animation.Play("fire");
		Debug.Log("Current Clip=" + animation.clip);
	}

	[Test]
	public void playDefault()
	{
		
		animation.Play("Default");
		//Debug.Log("Current Clip=" + animation.clip);
	}

	[Test]
	public void playClip1()
	{
		//animation.RemoveState("Default");
		//if(
		if(animation.GetState(kStateName) != null) {
			animation.Stop(kStateName);
			animation.RemoveState(kStateName);
		}
		animation.AddState(clip1, kStateName);
		animation.Play(kStateName);
	}

	[Test]
	public void playClip2()
	{
		if(animation.GetState(kStateName) != null) {
			animation.Stop(kStateName);
			animation.RemoveState(kStateName);
		}
		animation.AddState(clip2, kStateName);
		animation.Play(kStateName);
	}

	[Test]
	public void playIdle()
	{
		animation.Play();
	}
}
