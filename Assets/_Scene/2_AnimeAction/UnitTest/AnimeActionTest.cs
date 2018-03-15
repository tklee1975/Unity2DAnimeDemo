using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AnimeActionTest : BaseTest {

	public BattleVFX battleVFX;
	public GameCharacter enemy;

	public GameObject vfxPrefab;

	public GameCharacter enemy2;

	public GameCharacter player;

	[Test]
	public void SimpleVFXAction()
	{
		AnimeAction action = BattleVFXAction.Create(battleVFX, "Fire", enemy);
		//action
		action.Start();
	}

	[Test]
	public void VFXUsingPrefab()
	{
		AnimeAction action = BattleVFXAction.CreateWithPrefab(vfxPrefab, "Fire", enemy2);
		//action
		action.Start();
	}

	[Test]
	public void PlayerAttack()
	{
		// SubAction 
		AnimeAction subAction = BattleVFXAction.CreateWithPrefab(vfxPrefab, "Fire", enemy2);

		AnimeAction attackAction = CharAttackAction.Create(player, subAction);

		attackAction.Start();
	}
}
