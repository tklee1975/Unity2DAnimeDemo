using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXFinalTest : BaseTest {
	public VFX battleVFX;
	public GameCharacter targetCharacter;

	[Test]
	public void PlayVFX()
	{
		battleVFX.targetCharacter = targetCharacter;
		battleVFX.hitDamage = 1000;
		battleVFX.Play();
	}

}
