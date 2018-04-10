using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXFinalTest : BaseTest {
	public Animator vfxAnimator;

	[Test]
	public void StartVFX()
	{
		vfxAnimator.SetTrigger("Fire");
	}

}
