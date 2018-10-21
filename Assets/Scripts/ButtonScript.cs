using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	public GameObject b1, b2;
	static public GameObject B1, B2;
	static public AudioSource musiqueMenu;

	private void Start() {
		if(b1 != null && b2 != null)
		{
			B1 = b1;
			B2 = b2;
		}
		musiqueMenu = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
	}

	public void LoadGame() {
		SceneManager.LoadScene("Level",LoadSceneMode.Single);
	}

	public void LoadCredit() {
		musiqueMenu.Stop();
		b1.SetActive(false);
		b2.SetActive(false);
		SceneManager.LoadScene("Credit",LoadSceneMode.Additive);
	}

	public void LoadMenu() {
		ButtonScript.B1.SetActive(true);
		ButtonScript.B2.SetActive(true);
		ButtonScript.musiqueMenu.Play();
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Credit"));
	}
}
