using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	// Use this for initialization
	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont Destroy On Load:" + name);
	}
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}
	

	void OnLevelWasLoaded (int level)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		Debug.Log ("Playing AudioClip:" + thisLevelMusic);
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.Play ();
		}
	}
	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
}
