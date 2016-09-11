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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("player"))
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
