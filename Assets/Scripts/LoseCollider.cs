using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelmanager;
	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}
	void OnTriggerEnter2D(Collider2D collider ){
		levelmanager.LoadLevel ("03bLose");
		print ("Lose Collider");

	}

}
