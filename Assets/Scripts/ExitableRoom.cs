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
	//Be sure to assign roomValue first
	public void ConnectRoom(){
		Vector3 exit;

		//north
		exit = walls[0].transform.position;
		if (roomValue % 2 == 0) {
			Instantiate(hallways[0],exit,Quaternion.identity);
		}
		else{
			Instantiate(walls[0],exit,Quaternion.identity);
		}

		//east
		exit = exits[1].transform.position;
		if (roomValue % 3 == 0) {
			Instantiate(hallways[1],exit,Quaternion.identity);
		}
		else{
			Instantiate(walls[1],exit,Quaternion.identity);
		}

		//south
		if(!(roomValue % 5 == 0)){
			exit = exits[2].transform.position;
			Instantiate(walls[2],exit,Quaternion.identity);
		}

		//west
		if(!(roomValue % 7 == 0)){
			exit = exits[3].transform.position;
			Instantiate(walls[3],exit,Quaternion.identity);
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

