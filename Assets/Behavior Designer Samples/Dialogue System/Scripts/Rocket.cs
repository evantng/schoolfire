using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
    public Transform target;
    public float speed;
	public GameObject explosion;		// Prefab of explosion effect.

    private Transform thisTransform;

	void Start () 
	{
        thisTransform = GetComponent<Transform>();
	}

    void Update()
    {
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, target.position, speed * Time.deltaTime);
    }

	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
			// Call the explosion instantiation.
			OnExplode();

			// Destroy the rocket.
			Destroy (gameObject);

            // Destroy the enemy
            Destroy(col.gameObject);
		}
	}
}
