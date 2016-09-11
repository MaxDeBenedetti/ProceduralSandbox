using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt(Names.currentFloor, 1);
        PlayerPrefs.SetInt(Names.currentHealth, 100);
        PlayerPrefs.SetInt(Names.currentKills, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("TheDungeon");
        }
	}
}
