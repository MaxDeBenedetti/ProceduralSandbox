using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("player"))
        {
            SceneManager.LoadScene("TheDungeon");
        }
    }
}
