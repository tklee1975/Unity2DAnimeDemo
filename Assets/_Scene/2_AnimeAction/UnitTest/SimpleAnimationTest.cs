using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class SimpleAnimationTest : BaseTest {

	public AnimationClip clip1;
	public AnimationClip clip2;

	public SimpleAnimation animation;
	public SimpleAnimation animation2;

	const string kStateName = "Default";

	public void ChangeAnimation(AnimationClip cip, string stateName="Default") {
		if(animation.GetState(stateName) != null) {
			animation.Stop(stateName);
			animation.RemoveState(stateName);
		}
		animation.AddState(cip, stateName);
		animation.Play(stateName);
	}

	[Test]
	public void SetupAnime2() {
		//animation2.SetClip(clip1);
		// animation2.AddClip( )
		// animation2.Play();
		animation2.PlayClip(clip2);
	}

	[Test]
	public void SetupAnime1() {
		//animation2.SetClip(clip1);
		// animation2.AddClip( )
		// animation2.Play();
		animation2.PlayClip(clip1);
	}

	[Test]
	public void StopAnime2() {
		animation2.Stop();
	}

	[Test]
	public void testPlay() 
	{
		animation.Play();
	}

	[Test]
	public void testStop() 
	{
		animation.Stop();
	}

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
