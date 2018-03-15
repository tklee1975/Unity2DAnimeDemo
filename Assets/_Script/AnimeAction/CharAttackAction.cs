using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttackAction : AnimeAction {
	public GameCharacter actorCharacter = null;	
	public AnimeAction subAttackAction = null;		// 


	protected bool mHasReceiveAttackEvent = false;




	public static CharAttackAction Create(GameCharacter _actor, AnimeAction _subAttackAction) {
		CharAttackAction action = new CharAttackAction();

		action.Init(_actor, _subAttackAction);

		return action;
	}

	public void Init(GameCharacter _actorCharacter, AnimeAction _subAttackAction) {
		// mIsDone = false;
		// Debug.Log("BattleVFXAction: Init called");
		// mVFXObject = _vfxObj;
		// mVFXName = vfxName;

		actorCharacter = _actorCharacter;
		subAttackAction = _subAttackAction;

		
		actorCharacter.SetAnimeEventCallback((string eventName) => {
			//Debug.Log("BattleVFXAction: animeEvent. name=" + eventName);
			if(eventName == "attack") {
				//HitTarget();
				StartSubAttackAction();
			}
		});

		actorCharacter.SetAnimeEndCallback(() => {
			//if(onAttackAction == null || onA
			MarkAsDone();
		});
	}

	protected void StartSubAttackAction() {
		if(subAttackAction != null) {
			subAttackAction.Start();
		}
	}

	public override void Start() {
		//Debug.Log("BattleVFXAction: Started");
		actorCharacter.ChangeAnimeAction(GameCharacter.AnimeAction.Attack);
	}
	
	protected override void OnDone() {
		
	}

	public override void Step() {
		
	}
}
