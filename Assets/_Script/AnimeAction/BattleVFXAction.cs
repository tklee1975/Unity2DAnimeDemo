using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleVFXAction : AnimeAction {
	protected BattleVFX mVFXObject;
	protected string mVFXName = "";

	const float kVFXZPosition = -4.0f;

	public GameCharacter targetCharacter = null;	


	public static BattleVFXAction CreateWithPrefab(GameObject vfxPrefab, string vfxName, GameCharacter target) 
	{
		Debug.Log("CreateWithPrefab: target.pos=" + target.transform.position);
		Vector3 spawnPos = target.transform.position;
		spawnPos.z = kVFXZPosition;	// upp

		GameObject newObj = GameObject.Instantiate(vfxPrefab, spawnPos, Quaternion.identity);
		newObj.name = "BattleVFX_" + vfxName;
		newObj.transform.position = spawnPos;

		BattleVFX battleComp = newObj.GetComponent<BattleVFX>();


		return Create(battleComp, vfxName, target);		
	}

	public static BattleVFXAction Create(BattleVFX _vfxObj, string vfxName, GameCharacter target) {
		BattleVFXAction action = new BattleVFXAction();

		action.Init(_vfxObj, vfxName);
		action.targetCharacter = target;

		return action;
	}

	public void Init(BattleVFX _vfxObj, string vfxName) {
		mIsDone = false;
		Debug.Log("BattleVFXAction: Init called");
		mVFXObject = _vfxObj;
		mVFXName = vfxName;

		
		mVFXObject.SetAnimeEventCallback((string eventName) => {
			Debug.Log("BattleVFXAction: animeEvent. name=" + eventName);
			if(eventName == "hit") {
				HitTarget();
			}
		});

		mVFXObject.SetAnimeEndCallback(() => {
			MarkAsDone();
		});
	}

	protected void HitTarget() {
		if(targetCharacter != null) {
			targetCharacter.ChangeAnimeAction(GameCharacter.AnimeAction.Hit);
		}
	}


	public override void Start() {
		Debug.Log("BattleVFXAction: Started");
		mVFXObject.Play(mVFXName);
	}
	
	protected override void OnDone() {
		Object.Destroy(mVFXObject.gameObject);
	}

	public override void Step() {
		
	}
}
