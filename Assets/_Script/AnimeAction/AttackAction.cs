using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AnimeAction {
	public BattleModel actor;
	public AnimeAction onHitAction = null;
	public short style = 0;

	public bool isMoving = true;
	public Vector3 targetPostion;

	
	protected override void OnStart() {
		if(name == "") {
			name = "BattleAttack";
		}
		
		SetEndByCondition();		// When for 

		if(isMoving) {
			StartMovingAttack();
		} else {
			StartStandingAttack();
		}
	}

	protected void StartMovingAttack() {

		
		BattleModel.Callback hitCallback = () => {
			OnAttackHit();
		};


		BattleModel.Callback endCallback = () => {
			Debug.Log(" Move Bak done");
			MarkAsDone();
		};

		Debug.Log("Start Moving Fwd： targetPos=" + targetPostion);
		actor.MoveForward(targetPostion, () => {
			Debug.Log("Start Attack");
			actor.Attack(style, hitCallback, ()=> {
				Debug.Log("Start Move Bak");
				actor.MoveBack(endCallback);
			});
		});
	}

	protected void StartStandingAttack() {
		actor.Attack(style, OnAttackHit, MarkAsDone);
	}

	protected void OnAttackHit() {
		// Debug.Log("AttackAction: OnAttackHit");
		if(onHitAction != null) {
			AddSubAction(onHitAction);
		}
	}
}
