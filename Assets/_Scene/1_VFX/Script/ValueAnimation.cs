using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueAnimation : MonoBehaviour {
	public float duration = 0.5f;
	public float gravity = 5.0f;
	public bool autoDestroy = true;
	public Vector2 forceVector = new Vector2(10, 10);
	[Range(0, 1)] public float randomX = 0.5f;
	[Range(0, 1)] public float randomY = 0.5f;
	

	protected Vector2 mMoveForce = Vector2.zero;
	protected bool mStartMoving = false; 

	protected float mRemainTime = 0;

	protected TextMesh mText;

	protected Vector3 mOriginPosition;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{	
		mText = GetComponent<TextMesh>();
	}

	// Use this for initialization
	void Start () {
		
	}

	public void Show(int value, float dir) {		// dir +ve: jump to left, -ve jump to right
		mText.text = value.ToString();

		float normalDir = dir >= 0 ? -1 : 1;

		float vecX = (forceVector.x + Random.Range(0, randomX)) * normalDir;
		float vecY = forceVector.y + Random.Range(0, randomY);

		Move(new Vector2(vecX, vecY));
	}


	public void Move(Vector2 forceVec) {
		mMoveForce = forceVec;
		mRemainTime = duration;
		mStartMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(mStartMoving == false) {
			return;
		}

		if(mRemainTime <= 0) {
			RemoveSelf();
			return;
		}

		mRemainTime -= Time.deltaTime;
		UpdateTransform();
		UpdateForce();
	}

	void RemoveSelf() {
		mText.color = Color.clear;
		if(autoDestroy) {
			GameObject.Destroy(gameObject);
		}
	}

	void UpdateForce() {
		mMoveForce -= new Vector2(0, gravity);
	}

	void UpdateTransform() {
		Vector2 deltaPos = mMoveForce * Time.deltaTime;
		Vector3 newPos = transform.localPosition + new Vector3(deltaPos.x, deltaPos.y, 0);

		transform.localPosition = newPos;
	}
}
