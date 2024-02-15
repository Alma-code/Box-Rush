using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollectable : MonoBehaviour {
	public GameObject Collectable;
	
	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
		Destroy(Collectable,0.1f);
		}
		
	}

	
}
