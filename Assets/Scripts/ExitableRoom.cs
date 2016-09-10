using UnityEngine;
using System.Collections;

	public class ExitableRoom : MonoBehaviour {

	public GameObject[] hallways;
	public GameObject[] walls;
	public GameObject[] exits;
	public int roomValue;
	public int roomLocX, roomLocY;
    public float roomScale = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Connects this room to other rooms using hallways
	//If there is not a connection between rooms, it creates a wall instead
	//Be sure to assign roomValue first
	public void ConnectRoom(float hallLength = 1){
		Vector3 exit;
		GameObject nObject;

        Transform t;

        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(90, 0, 0);

        //north
        if (roomValue % 2 == 0) {
			nObject = (GameObject)Instantiate(hallways[0],Vector3.zero, rotation);
            nObject.transform.localScale *= hallLength;
        }
		else{
			nObject = (GameObject)Instantiate(walls[0],Vector3.zero, rotation);
            nObject.transform.localScale = new Vector3(roomScale, 1f, roomScale);
		}
		exit = exits [0].transform.position;
		nObject.transform.position = exit;
        

		//east
		exit = exits[1].transform.position;
		if (roomValue % 3 == 0) {
            nObject = (GameObject)Instantiate(hallways[1],exit, rotation);
            nObject.transform.localScale *= hallLength;
        }
		else{
            nObject = (GameObject)Instantiate(walls[1],exit, rotation);
            nObject.transform.localScale = new Vector3(1f, roomScale, roomScale);
        }
        

        //south
        if (!(roomValue % 5 == 0)){
			exit = exits[2].transform.position;
            nObject = (GameObject)Instantiate(walls[2],exit, rotation);
            nObject.transform.localScale = new Vector3(roomScale, 1f, roomScale);
        }
       

        //west
        if (!(roomValue % 7 == 0)){
			exit = exits[3].transform.position;
            nObject = (GameObject)Instantiate(walls[3],exit, rotation);
            nObject.transform.localScale = new Vector3(1f, roomScale, roomScale);
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

