using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AnimeAction {
	public BattleModel actor;
	public AnimeAction onHitAction = null;
	public short style = 0;

	public bool isMoving = true;
	public Vector2 targetPostion = new Vector2(0, 0);

	
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

		Vector2 endPos = targetPostion;

		BattleModel.Callback hitCallback = () => {
			OnAttackHit();
		};


		BattleModel.Callback endCallback = () => {
			MarkAsDone();
		};

		actor.MoveForward(endPos, () => {
			actor.Attack(style, hitCallback, ()=> {
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
			StartAction(onHitAction);
		}
	}
}
