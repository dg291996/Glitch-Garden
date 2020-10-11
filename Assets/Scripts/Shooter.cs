using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;
	 
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){
		animator = GameObject.FindObjectOfType<Animator> ();
	
		//creates parent if necessary
			projectileParent =GameObject.Find ("Projectiles");
		if(!projectileParent){
			projectileParent= new GameObject("Projectiles") ;

		}
		setMyLaneSpawner ();
		print (myLaneSpawner);
	}
	void Update(){
	if (isAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}
	//Look through all spawners, and set myLaneSpawner if found
	void setMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
	
			}
		}

		Debug.LogError (name + "cant find spawnerin lane");
	}
	bool isAttackerAheadInLane(){
		//Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		//if there are attckers,are they ahead?
		foreach (Transform Attacker in myLaneSpawner.transform) {
			if (Attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//Attacker in lane,but behind us
		return false;

	}
	
	private void Fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;

	}

}
