using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] attackerPrefabArray;

	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn(GameObject myGameObject){
	GameObject myAttacker=Instantiate(myGameObject)as GameObject;
	myAttacker.transform.parent=transform;
	myAttacker.transform.position=transform.position;
}

	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSeconds = 1 / meanSpawnDelay;
		if(Time.deltaTime> meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped");
		}
		float threshold = spawnsPerSeconds * Time.deltaTime / 5;
		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}

		}
	}
