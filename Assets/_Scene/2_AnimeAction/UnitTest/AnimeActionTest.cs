using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AnimeActionTest : BaseTest {
	public AnimeActionManager actionManager;

	public Animator animator1;
	public Animator animator2;
	public Animator charAnimator;
	public Animator enemyAnimator;
	public Animator enemyAnimator2;
	
	public BattleVFX battleVFX1;
	public BattleVFX battleVFX2;
	public GameCharacter enemy;

	public GameObject vfxPrefab;

	public GameCharacter enemy2;

	public GameCharacter player;

	public GameObject hitValuePrefab;

	[Test]
	public void DelayAction()
	{
		DelayAction action = new DelayAction();
		action.SetDuration(1.0f);


		actionManager.RunAction(action);
	}

	[Test]
	public void HitValue()
	{
		HitValueAction action = new HitValueAction();
		action.valueTextPrefab = hitValuePrefab;
		action.hitValue = 1000;
		action.position = new Vector3(0, 0, -2);
		

		actionManager.RunAction(action);
	}

	[Test]
	public void VFX1()
	{
		AnimatorAction action = new AnimatorAction();
		action.name = "vfx1";
		action.animator = animator1;
		action.triggerState = "Fire";

		actionManager.RunAction(action);
		//action.animator = bat
	}

	[Test]
	public void VFX2()
	{
		AnimatorAction action = new AnimatorAction();
		action.name = "vfx2";
		action.animator = animator1;
		action.triggerState = "Thunder";

		actionManager.RunAction(action);
		//action.animator = bat
	}

	[Test]
	public void VFXAction()
	{
		VFXAction action = new VFXAction();
		action.name = "vfxAction";
		action.vfxName = "Thunder";
		action.position = new Vector3(0, 0, -2);
		action.vfxPrefab = vfxPrefab;

		actionManager.RunAction(action);
		//action.animator = bat
	}


	[Test]
	public void SequenceTest()
	{
		List<AnimeAction> actionList = new List<AnimeAction>();	
		AnimatorAction action;
		
		action = new AnimatorAction();
		action.name = "vfx1";
		action.animator = animator1;
		action.triggerState = "Thunder";
		actionList.Add(action);

		action = new AnimatorAction();
		action.name = "vfx2";
		action.animator = animator2;
		action.triggerState = "Fire";
		actionList.Add(action);

		DelayAction delay = new DelayAction();
		delay.SetDuration(1.0f);
		actionList.Add(delay);

		action = new AnimatorAction();
		action.name = "vfx3";
		action.animator = animator1;
		action.triggerState = "Thunder";
		actionList.Add(action);


		SequenceAction sequence = new SequenceAction();
		sequence.name = "sequence";
		sequence.AddActionList(actionList);

		actionManager.RunAction(sequence);
		//action.animator = bat
	}





	[Test]
	public void ParallelTest()
	{
		ParallelAction parallel = new ParallelAction();
		parallel.name = "parallel";
		


		//AnimatorAction action;
		
		HitValueAction hitAction;
		
		hitAction = new HitValueAction();
		hitAction.valueTextPrefab = hitValuePrefab;
		hitAction.hitValue = 999;
		hitAction.position = new Vector3(0, 2, -2);
		parallel.AddAction(hitAction);

		hitAction = new HitValueAction();
		hitAction.valueTextPrefab = hitValuePrefab;
		hitAction.hitValue = 888;
		hitAction.position = new Vector3(1, 1, -2);
		parallel.AddAction(hitAction);

		hitAction = new HitValueAction();
		hitAction.valueTextPrefab = hitValuePrefab;
		hitAction.hitValue = 777;
		hitAction.position = new Vector3(2, 0, -2);
		parallel.AddAction(hitAction);
		

		DelayAction delay = new DelayAction();
		delay.SetDuration(2.0f);
		parallel.AddAction(delay);

		// 
		actionManager.RunAction(parallel);
		//action.animator = bat
	}

	[Test]
	public void CharCast() {
		AnimatorAction action;
		action  = new AnimatorAction();
		action.name = "character";
		action.animator = charAnimator;
		action.triggerState = "Cast";


		AnimatorAction fireAction = new AnimatorAction();
		fireAction.name = "vfx2";
		fireAction.animator = animator2;
		fireAction.triggerState = "Fire";
		action.onHitAction = fireAction;

		actionManager.RunAction(action);
	}

	[Test]
	public void CharCast2() {
		SequenceAction sequence = new SequenceAction();
		sequence.name = "CastSequence";

		AnimatorAction action;
		action  = new AnimatorAction();
		action.doneWhenHit = true;
		action.name = "character";
		action.animator = charAnimator;
		action.triggerState = "Cast";
		sequence.AddAction(action);


		AnimatorAction fireAction = new AnimatorAction();
		fireAction.name = "vfx2";
		fireAction.animator = animator2;
		fireAction.triggerState = "Fire";
		sequence.AddAction(fireAction);

		actionManager.RunAction(sequence);
	}


	[Test]
	public void EnemyHit()
	{
		SequenceAction sequence = new SequenceAction();
		sequence.name = "HitSequence";

		AnimatorAction action = new AnimatorAction();
		action.name = "enemyHit";
		action.animator = enemyAnimator;
		action.triggerState = "Hit";
		sequence.AddAction(action);


		HitValueAction hitAction = new HitValueAction();
		hitAction.valueTextPrefab = hitValuePrefab;
		hitAction.hitValue = 1000;
		hitAction.position = enemyAnimator.transform.position + new Vector3(0, 1, -2);
		sequence.AddAction(hitAction);
		//hitAction.position = new Vector3(0, 0, -2);

		actionManager.RunAction(sequence);
		//action.animator = bat
	}



	public AnimeAction CreateCastAction(string name, string vfx, Animator target, int damage)
	{
		SequenceAction sequence = new SequenceAction();
		sequence.name = name;

		Vector3 targetPosition = target.transform.position;

		AnimatorAction animeAction;

		

		VFXAction vfxAction = new VFXAction();
		vfxAction.name = "vfxAction";
		vfxAction.vfxName = vfx;
		vfxAction.position = targetPosition + new Vector3(0, 0, -2);
		vfxAction.vfxPrefab = vfxPrefab;
		sequence.AddAction(vfxAction);

		animeAction = new AnimatorAction();
		animeAction.name = "enemyHit";
		animeAction.animator = target;
		animeAction.triggerState = "Hit";
		sequence.AddAction(animeAction);


		HitValueAction hitAction = new HitValueAction();
		hitAction.valueTextPrefab = hitValuePrefab;
		hitAction.hitValue = damage;
		hitAction.position = targetPosition + new Vector3(0, 1, -2);
		sequence.AddAction(hitAction);

		return sequence;
	}


	[Test]
	public void SingleTarget()
	{
		AnimeAction targetAction = CreateCastAction("fire", "Fire", enemyAnimator, 1000);
		
		AnimatorAction animeAction = new AnimatorAction();
		animeAction.name = "character";
		animeAction.animator = charAnimator;
		animeAction.triggerState = "Cast";
		animeAction.onHitAction = targetAction;

		//AnimeAction action = 

		actionManager.RunAction(animeAction);
	}

	[Test]
	public void MultiTarget()
	{
		ParallelAction parallel = new ParallelAction();
		parallel.name = "SkillCast";

		string vfx = "Thunder";

		AnimeAction action1 = CreateCastAction("target1", vfx, enemyAnimator, 1000);
		parallel.AddAction(action1);

		AnimeAction action2 = CreateCastAction("target2", vfx, enemyAnimator2, 777);
		parallel.AddAction(action2);


		AnimatorAction animeAction = new AnimatorAction();
		animeAction.name = "character";
		animeAction.animator = charAnimator;
		animeAction.triggerState = "Cast";
		animeAction.onHitAction = parallel;

		actionManager.RunAction(animeAction);
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
