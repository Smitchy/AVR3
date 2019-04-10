using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCapture : MonoBehaviour {

	public Animator anim;
    public GameObject[] particles;
    public AudioSource source;
    public AudioClip fireworks;
    
	private void OnTriggerEnter(Collider other) {
		ScoreSystem.Instance.Catch();
		Destroy(other.gameObject);
        Instantiate(particles[Random.Range(0, particles.Length)], transform.position, Quaternion.identity);
        source.PlayOneShot(fireworks);
    }
}
