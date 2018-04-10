using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXEventTest : BaseTest {
	public Animator vfxAnime = null;

	[Test]
	public void StartVFX()
	{
		vfxAnime.SetTrigger("Fire");
	}
}
