using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using DG.Tweening;

public class DamageValueTest : BaseTest {
	public TextMesh textMesh;
	public ValueAnimation valueAnimation;
	[Range(-10, 10)] public float forceX = -3;
	[Range(0, 20)] public float forceY = 5;

	public GameCharacter gameCharacter;

	[Test]
	public void GetHit() {
		gameCharacter.GetHit(-10000);
	}

	[Test]
	public void ShowDamage() {
		gameCharacter.ShowDamageText(-100);
	}

	[Test]
	public void ShowText() {
		valueAnimation.GetComponent<TextMesh>().color = Color.red;
		valueAnimation.transform.localPosition = new Vector3(0, 0.2f, -3);
		valueAnimation.Show(-10);
	}

	[Test]
	public void MoveText() {
		valueAnimation.GetComponent<TextMesh>().color = Color.red;
		valueAnimation.transform.localPosition = Vector3.zero;
		valueAnimation.Move(new Vector2(forceX, forceY));
	}

	[Test]
	public void JumpText()
	{
		Transform objectTF = textMesh.transform;
		Vector3 targetPos = objectTF.localPosition - new Vector3(1, 0, 0);
		textMesh.transform.DOLocalJump(targetPos, 1.3f, 1, 0.5f);
		//textMesh.
	}

}
