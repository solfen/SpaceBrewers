using UnityEngine;
using System.Collections;

public class AnimationRobotBarman : MonoBehaviour {

	public Animator robotBarman;
	private float rng = 0.0f;
	int actualAnim = -1;
	
	// 80% de chance de boire une biere
	// 70% Cleaning
	// 50% Fucking
	// 30% poisoning beer
	// 20% fridge
	// 20% Load



	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool isPlaying = AnimatorIsPlaying ();
		AnimatorStateInfo currentState = robotBarman.GetCurrentAnimatorStateInfo(0);
		
		if (!isPlaying || currentState.IsName("Idle")) {
			rng = Random.Range (0, 270);

			//80%
			if (rng >= 0 && rng <= 79) {
				actualAnim = 0;
				SetActiveAnim(0);
			}
			//70%
			else if (rng >= 80 && rng < 149) {
				actualAnim = 1;
				SetActiveAnim(1);
			}
			//50%
			else if (rng >= 150 && rng < 200) {
				actualAnim = 2;
				SetActiveAnim(2);
			}
			// 30%
			else if (rng >= 201 && rng < 230) {
				actualAnim = 3;
				SetActiveAnim(3);
			}
			// 20%
			else if (rng >= 231 && rng < 250) {
				actualAnim = 4;
				SetActiveAnim(4);
			}
			// 20 %
			else if (rng >= 251 && rng < 270) {
				actualAnim = 5;
				SetActiveAnim(5);
			}
		}
		else
		{
			Debug.Log ("isPlaying");
			SetActiveAnim(-1);
		}
	}

	void SetActiveAnim(int actualAnim)
	{
		if (actualAnim == -1) {
			robotBarman.SetBool ("isLoading", false);
			robotBarman.SetBool ("isCleaningBar", false);
			robotBarman.SetBool ("isFucking", false);
			robotBarman.SetBool ("isPoisonningBeer", false);
			robotBarman.SetBool ("isFridge", false);
			robotBarman.SetBool ("isLoading", false);
		}
		if (actualAnim == 0) {
			robotBarman.SetBool ("isLoading", true);
			robotBarman.SetBool ("isCleaningBar", false);
			robotBarman.SetBool ("isFucking", false);
			robotBarman.SetBool ("isPoisonningBeer", false);
			robotBarman.SetBool ("isFridge", false);
			robotBarman.SetBool ("isLoading", false);
		}
		if (actualAnim == 1) {
			robotBarman.SetBool ("isLoading", false);
			robotBarman.SetBool ("isCleaningBar", true);
			robotBarman.SetBool ("isFucking", false);
			robotBarman.SetBool ("isPoisonningBeer", false);
			robotBarman.SetBool ("isFridge", false);
			robotBarman.SetBool ("isLoading", false);
			
		}
		if (actualAnim == 2) {
			robotBarman.SetBool ("isLoading", false);
			robotBarman.SetBool ("isCleaningBar", false);
			robotBarman.SetBool ("isFucking", true);
			robotBarman.SetBool ("isPoisonningBeer", false);
			robotBarman.SetBool ("isFridge", false);
			robotBarman.SetBool ("isLoading", false);
		}
		if (actualAnim == 3) {
			robotBarman.SetBool ("isLoading", false);
			robotBarman.SetBool ("isCleaningBar", false);
			robotBarman.SetBool ("isFucking", false);
			robotBarman.SetBool ("isPoisonningBeer", true);
			robotBarman.SetBool ("isFridge", false);
			robotBarman.SetBool ("isLoading", false);
		}
		if (actualAnim == 4) {
			robotBarman.SetBool ("isLoading", false);
			robotBarman.SetBool ("isCleaningBar", false);
			robotBarman.SetBool ("isFucking", false);
			robotBarman.SetBool ("isPoisonningBeer", false);
			robotBarman.SetBool ("isFridge", true);
			robotBarman.SetBool ("isLoading", false);
		}
		if (actualAnim == 5) {
			robotBarman.SetBool ("isLoading", false);
			robotBarman.SetBool ("isCleaningBar", false);
			robotBarman.SetBool ("isFucking", false);
			robotBarman.SetBool ("isPoisonningBeer", false);
			robotBarman.SetBool ("isFridge", false);
			robotBarman.SetBool ("isLoading", true);
		}
	}

	bool AnimatorIsPlaying()
	{
		AnimatorStateInfo currentState = robotBarman.GetCurrentAnimatorStateInfo(0);

		Debug.Log ("time : " + (currentState.normalizedTime % 1) + " / " + robotBarman.GetCurrentAnimatorStateInfo(0).length);
		
		return (robotBarman.GetCurrentAnimatorStateInfo(0).length > (currentState.normalizedTime % 1));
	}
}
