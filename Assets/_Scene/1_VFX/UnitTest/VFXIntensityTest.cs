using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXIntensityTest : BaseTest {
	public Animator[] animatorList;
	
	[Test]
	public void Trigger()
	{
		//Debug.Log("###### TEST 1 ######");
		foreach(Animator a in animatorList) {
			a.SetTrigger("fire");
		}
	}

}
