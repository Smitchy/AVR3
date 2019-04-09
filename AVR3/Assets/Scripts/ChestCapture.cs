using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCapture : MonoBehaviour {

	public Animator anim;
	private void OnTriggerEnter(Collider other) {
		ScoreSystem.Instance.Catch();
		Destroy(other);
		anim.SetBool("open", false);
	}
}
