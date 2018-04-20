using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AnimeActionTest : BaseTest {
	public AnimeActionManager actionManager;

	public Animator animator1;
	public Animator animator2;
	
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
