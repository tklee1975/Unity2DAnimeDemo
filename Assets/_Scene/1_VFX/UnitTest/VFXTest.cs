using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class VFXTest : BaseTest {
	public AnimationClip fireClip = null;
	public AnimationClip thunderClip = null;

	public BattleVFX battleVFX;
	public GameCharacter gameCharacter;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		if(battleVFX != null) {
			battleVFX.SetAnimeEventCallback((string value) => {
				Debug.Log("AnimeEvent: received. value=" + value);

				if(gameCharacter != null) {
					gameCharacter.ChangeAnimeAction(GameCharacter.AnimeAction.Hit);
				}
			});

			battleVFX.SetAnimeEndCallback(() => {
				Debug.Log("AnimeEvent: Animation End");
			});
		}
	}

	[Test]
	public void testFire()
	{
		battleVFX.Play("Fire");
	}

	[Test]
	public void testThunder()
	{
		battleVFX.Play("Thunder");
	}
}
