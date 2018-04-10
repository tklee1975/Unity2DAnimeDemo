using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXAnimeTest : BaseTest {
	public Animation animation;
	public Animator animator;
	public AnimationClip animationClip;
	public SimpleAnimation simpleAnime;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//simpleAnime.
	}

	[Test]
	public void PlayAnime()
	{
		animation.Play();
	}

	[Test]
	public void PlayAnimator()
	{
		animator.SetTrigger("active");
	}

	[Test]
	public void PlaySimpleAnime()
	{
	
		if(simpleAnime.GetState("fire") == null) {
			//animationClip.wrapMode = WrapMode.Once;
			animationClip.wrapMode = WrapMode.Clamp;		// Same as Once
			//animationClip.wrapMode = WrapMode.ClampForever;
			simpleAnime.AddClip(animationClip, "fire");
		}
		simpleAnime.Play("fire");
		//simpleAnime.Play()
		//simpleAnime.CrossFade("fire_anime");
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		// if(animation.isPlaying) {
		// 	animation.CrossFade();
		// }
		//animation.
		//Debug.Log("Animation.isPlaying=" + animation.isPlaying);
	}

	[Test]
	public void PlayClip()
	{
		animationClip.legacy = false;
		//animationClip.
	}
}
