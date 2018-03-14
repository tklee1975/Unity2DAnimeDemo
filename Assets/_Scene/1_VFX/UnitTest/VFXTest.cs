using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXTest : BaseTest {
	public AnimationClip fireClip = null;
	public AnimationClip thunderClip = null;

	public BattleVFX battleVFX;

	[Test]
	public void testFire()
	{
		battleVFX.Play("Fire");
	}

	[Test]
	public void testThunder()
	{
		battleVFX.Play("Thunder");
	}
}
