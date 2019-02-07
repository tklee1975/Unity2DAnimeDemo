using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class SingleActionTest : BaseTest {
	public BattleModel leftPlayer;
	public BattleModel rightPlayer;

	public AnimeActionManager actionManager;

	[Header("Effects")]
	public AnimationClip[] skillEffect;
	public AnimationClip[] slashEffect;

	[Header("Other Setting")]
	public GameObject hitValuePrefab;

	[Test]
	public void Attack()
	{
		AttackAction attack = CreateAttackAction(rightPlayer, leftPlayer, 0, true, null);
		actionManager.StartAction(attack);
	}

	[Test]
	public void SkillVFX()
	{
		AnimeAction action = CreateEffectAction(leftPlayer, skillEffect[0]);
		actionManager.StartAction(action);
	}

	[Test]
	public void SlashVFX()
	{
		AnimeAction action = CreateEffectAction(leftPlayer, slashEffect[0]);
		actionManager.StartAction(action);
	}

	[Test]
	public void Hit()
	{
		AnimeAction action = CreateHitAction(leftPlayer);
		actionManager.StartAction(action);
	}

	[Test]
	public void DamageText()
	{
		AnimeAction action = CreateHitValueAction(leftPlayer);
		actionManager.StartAction(action);
	}

	// [Test]
	// public void Die()
	// {
	// 	Debug.Log("###### TEST 2 ######");
	// }



	#region Action 

	public AttackAction CreateAttackAction(BattleModel actor, BattleModel target, 
							short style, bool isMoving, AnimeAction onHitAction) {
		AttackAction attackAction = new AttackAction();
		attackAction.actor = actor;
		attackAction.style = style;
		attackAction.isMoving = isMoving;
		attackAction.targetPostion = target.GetHitPosition() + new Vector3(0, 0, -5);
		attackAction.onHitAction = onHitAction;
		
		return attackAction;
	}

	public AnimeAction CreateHitAction(BattleModel targetModel) {
		HitAction action = new HitAction();
		action.actor = targetModel;

		return action;
		// SimpleAnimationAction effectAction = new SimpleAnimationAction();
		// effectAction.clip = hitEffect;
		// effectAction.spawnPosition = targetModel.transform.position  + new Vector3(0, 1, -2);
		
	}

	public AnimeAction CreateEffectAction(BattleModel targetModel, AnimationClip hitEffect) {
		SimpleAnimationAction effectAction = new SimpleAnimationAction();
		effectAction.clip = hitEffect;
		effectAction.spawnPosition = targetModel.transform.position  + new Vector3(0, 1, -2);
		
		return effectAction;
	}

	public AnimeAction CreateHitValueAction(BattleModel targetModel) {
		HitValueAction damageAction = new HitValueAction();
		damageAction.valueTextPrefab = hitValuePrefab;
		damageAction.hitValue = Random.Range(100, 999);
		damageAction.position = targetModel.transform.position + new Vector3(0, 2, -2);
		return damageAction;
	}

	#endregion
}
