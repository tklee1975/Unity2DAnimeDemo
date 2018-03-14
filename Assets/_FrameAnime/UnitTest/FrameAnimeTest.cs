using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class FrameAnimeTest : BaseTest {
	public GameCharacter testCharacter;
	public GameCharacter testEnemy;

	[Test]
	public void Idle()
	{
		testCharacter.ChangeAnimeAction(GameCharacter.AnimeAction.Idle);
	}

	[Test]
	public void Attack()
	{
		testCharacter.ChangeAnimeAction(GameCharacter.AnimeAction.Attack);
	}

	[Test]
	public void CastMagic()
	{
		testCharacter.ChangeAnimeAction(GameCharacter.AnimeAction.CastMagic);
	}

	[Test]
	public void EnemyHit()
	{
		testEnemy.ChangeAnimeAction(GameCharacter.AnimeAction.Hit);
	}
}
