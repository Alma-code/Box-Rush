using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectable : MonoBehaviour {
	
	public GameObject[] ObstaclePrehab;
	
	public Vector3 center;
	public Vector3 size;
	public GameObject player;
	public float Distravelled;
    public int Counter;
	public int ref1;
	public int TimeDiff;
	
	// Use this for initialization
	public void Start () {
	 Counter = TimeDiff;
	 ref1 = 0;
	InvokeRepeating("SpawnCollectable1",0.1f, 0.3f);
	
	}
	
	void Update () {
		
	   Debug.Log(Counter + "Counter");
	   Distravelled = player.transform.position.z;
	   
	   if (Distravelled >= 16400)
	   {
	  CancelInvoke("SpawnCollectable1");
	   }
	  }
	
	
	
	public void Cancel_Invoke()
	{
		CancelInvoke("SpawnCollectable1");
	}


	
	 public void SpawnCollectable1()
	{
	 GameObject SpawnedObstacle;
	 Vector3 pos = transform.localPosition + center + new Vector3(Random.Range(-size.x/2, size.x/ 2),Random.Range(-size.y/2, size.y/ 2),Random.Range(-size.z/2, size.z/ 2));
	 
	 SpawnedObstacle = Instantiate(ObstaclePrehab[Random.Range(0,ObstaclePrehab.Length)], pos, Quaternion.identity);
	 
	}
	

	
	void OnDrawGizmosSelected()
	{

	Gizmos.DrawCube(transform.localPosition + center, size);
	}

}   
