using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour {
	
	public GameObject target;
	public float particleDuration = 0.5f;
	Vector2 dir;
	
	void Start ()
	{
		this.rigidbody2D.AddForce(new Vector2(Random.Range(500, 750), Random.Range(-100, 100)));
	}
	
	void Update () 
	{
		if(gameObject.activeInHierarchy)
		{
			transform.position = Vector2.Lerp(transform.position, target.transform.position, 0.5f*Time.deltaTime);
			StartCoroutine(DeactivateParticle());
		}
	}

	IEnumerator DeactivateParticle()
	{
		yield return new WaitForSeconds(particleDuration);
		gameObject.SetActive(false);
	}
}
