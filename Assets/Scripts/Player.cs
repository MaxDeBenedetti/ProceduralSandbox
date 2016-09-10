using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = Vector3.right * Input.GetAxis ("Horizontal") * speed + Vector3.forward * Input.GetAxis("Vertical") * speed;
		if(Input.GetKey(KeyCode.Escape)){
		   Application.Quit();
		}
		if(Input.GetKey(KeyCode.N))
            
			Application.LoadLevel("TheDungeon");
	}

	void OnCollisionEnter(Collision collision){
		if(collision.collider.gameObject.tag.Equals("exit")){
			Application.LoadLevel("TheDungeon");
		}
	}
}
