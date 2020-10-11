using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	void Awake()
	{
		Debug.Log ("Music player Awake" + GetInstanceID ());
		if (instance!= null) // instance is Music Player
		{
			Destroy (gameObject);
			print ("Duplicate music player self destructing");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject.gameObject);  // Here gameObject refers to assets of Music Player
			
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Music player Start" + GetInstanceID ());


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
