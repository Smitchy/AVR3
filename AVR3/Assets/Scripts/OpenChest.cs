using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {
	public Animator anim;

	private void OnTriggerEnter(Collider other) {
		anim.SetBool("open", true);
	}
}
