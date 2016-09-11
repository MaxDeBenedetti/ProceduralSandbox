using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    private bool skipLoad = false;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt(Names.currentFloor, 1);
        PlayerPrefs.SetInt(Names.currentHealth, 100);
        PlayerPrefs.SetInt(Names.currentKills, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        else if (Input.anyKey)
        {
            SceneManager.LoadScene("TheDungeon");
        }
	}
}
