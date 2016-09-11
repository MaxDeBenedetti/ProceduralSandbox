using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIcounts : MonoBehaviour {

    public Text killCount, floorCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        killCount.text = "" + PlayerPrefs.GetInt(Names.currentKills);
        floorCount.text = "" + PlayerPrefs.GetInt(Names.currentFloor);
	}
}
