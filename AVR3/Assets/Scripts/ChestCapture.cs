using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCapture : MonoBehaviour {

	public Animator anim;
    public GameObject[] particles;
    public AudioSource source;
    public AudioClip fireworks;
    
	private void OnTriggerEnter(Collider other) {
        if(other.tag == "SpawnAble")
        {
            if (other.GetComponent<CapturablesMovement>().captured)
            {
                ScoreSystem.Instance.Catch();
		        Destroy(other.gameObject);
                source.PlayOneShot(fireworks);
                StartCoroutine(ParticleEffect());
            }
        }
    }

    IEnumerator ParticleEffect()
    {
        GameObject part = Instantiate(particles[Random.Range(0, particles.Length)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(part);
    }
}
