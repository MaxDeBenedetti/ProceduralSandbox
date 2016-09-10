using UnityEngine;
using System.Collections;

	public class ExitableRoom : MonoBehaviour {

	public GameObject[] hallways;
	public GameObject[] walls;
	public GameObject[] exits;
	public int roomValue;
	public int roomLocX, roomLocY;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Connects this room to other rooms using hallways
	//If there is not a connection between rooms, it creates a wall instead
	//Be sure to assign roomValue first
	public void ConnectRoom(){
		Vector3 exit;
		GameObject nObject;

        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(90, 0, 0);

        //north
        if (roomValue % 2 == 0) {
			nObject = (GameObject)Instantiate(hallways[0],Vector3.zero, rotation);
		}
		else{
			nObject = (GameObject)Instantiate(walls[0],Vector3.zero, rotation);
		}
		exit = exits [0].transform.position;
		nObject.transform.position = exit;

		//east
		exit = exits[1].transform.position;
		if (roomValue % 3 == 0) {
			Instantiate(hallways[1],exit, rotation);
		}
		else{
			Instantiate(walls[1],exit, rotation);
		}

		//south
		if(!(roomValue % 5 == 0)){
			exit = exits[2].transform.position;
			Instantiate(walls[2],exit, rotation);
		}

		//west
		if(!(roomValue % 7 == 0)){
			exit = exits[3].transform.position;
			Instantiate(walls[3],exit, rotation);
		}

	}

	public int RoomValue {
		get {
			return this.roomValue;
		}
		set {
			roomValue = value;
		}
	}

	public int RoomLocX {
		get {
			return this.roomLocX;
		}
		set {
			roomLocX = value;
		}
	}

	public int RoomLocY {
		get {
			return this.roomLocY;
		}
		set {
			roomLocY = value;
		}
	}

}

