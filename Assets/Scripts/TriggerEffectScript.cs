using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEffectScript : MonoBehaviour {

	public void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	} 
}
