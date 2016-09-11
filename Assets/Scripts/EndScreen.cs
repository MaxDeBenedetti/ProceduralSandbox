using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public Text curFloor, curKill, highFloor, highKills;

	// Use this for initialization
	void Start () {

        //change the text to display scores
        curFloor.text = "" + PlayerPrefs.GetInt(Names.currentFloor);
        curKill.text = "" + PlayerPrefs.GetInt(Names.currentKills);

        //change high floor if new is better
        if (!PlayerPrefs.HasKey(Names.highFloor) || PlayerPrefs.GetInt(Names.highFloor) < PlayerPrefs.GetInt(Names.currentFloor)) 
        {
            PlayerPrefs.SetInt(Names.highFloor, PlayerPrefs.GetInt(Names.currentFloor));
        }

        highFloor.text = "" + PlayerPrefs.GetInt(Names.highFloor);

        //change high kills if new is better
        if (!PlayerPrefs.HasKey(Names.highKills) || PlayerPrefs.GetInt(Names.highKills) < PlayerPrefs.GetInt(Names.currentKills))
        {
            PlayerPrefs.SetInt(Names.highKills, PlayerPrefs.GetInt(Names.currentKills));
        }

        highKills.text = "" + PlayerPrefs.GetInt(Names.highKills);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("StartScreen");
        }
	}
}
