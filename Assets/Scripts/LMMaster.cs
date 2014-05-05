using UnityEngine;
using System.Collections;

public class LMMaster : MonoBehaviour
{

    public int[,] grid;
    public int gridWidth, gridHeight;
	public ExitableRoom cub;
    public int numOfRooms;
	public float roomLength, hallLength;
	public GameObject player, exit;


    // Use this for initialization
    void Start()
    {
		//initiallizes a numeric grid where every element is 0
        grid = new int[gridWidth, gridHeight];
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                grid[i, j] = 0;
            }
        }

        int firstX = gridWidth / 2;
        int firstY = gridHeight / 2;

		//set the middle element to 1
        grid[firstX, firstY] = 1;

		//Begins step 1
        RoomAdder adder = new RoomAdder(firstX, firstY, grid, numOfRooms);
        int[] room;//A two element array that represents a single room
        while (adder.RoomCount < numOfRooms)
        {
            room = RoomAdder.PickRoom(adder.RoomCount, adder.RoomList);
            NeighborCheck(grid, room[0], room[1], adder);
            adder.Process();
        }

		//Begins step 2
        RoomEvaluator eval = new RoomEvaluator(grid, numOfRooms);
		//Processes the entire grid
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (grid[i, j] != 0)
                {
                    eval.AddCenter(i, j);
                    NeighborCheck(grid, i, j, eval);
                    eval.Process();
                }
            }
        }

		//begins step 3
		roomify();
    }

    // Update is called once per frame
    void Update()
    {

    }

	/*
	 * feeds the neighbors of a given room to process object p
	 */
    public void NeighborCheck(int[,] grid, int row, int colum, ProcessObject p)
    {
        if (row - 1 >= 0)
            p.AddNeighbor(row - 1, colum);
        if (row + 1 < gridWidth)
            p.AddNeighbor(row + 1, colum);
        if (colum - 1 >= 0)
            p.AddNeighbor(row, colum - 1);
        if (colum + 1 < gridHeight)
            p.AddNeighbor(row, colum + 1);
    }

	/*
	 * Instantiates the rooms
	 */
	private void roomify(){
		Vector3 startPos = new Vector3(-6f,3f,0f);//Hardcoded, for now, as it will not matter once every room has a camera
		bool exitNotAdded = true;
		ExitableRoom tc;
		for(int i =0; i < gridWidth; i++){
			for(int j=0; j <gridHeight; j++){

				if(grid[i,j] != 0){

					//block moves the player and exit into position
					if(exitNotAdded){//Adds the exit to the first room instantiated
						exit.transform.position = new Vector3(startPos.x+j*(roomLength+hallLength),startPos.y-i*(roomLength+hallLength),-0.5f);
						exitNotAdded = false;
					}
					player.rigidbody.position = new Vector3(startPos.x+j*(roomLength+hallLength),startPos.y-i*(roomLength+hallLength),-0.5f);//places the player in the last room instantiated

					//Instantiates a room
					tc = (ExitableRoom)Instantiate(cub,new Vector3(startPos.x+j*(roomLength+hallLength),startPos.y-i*(roomLength+hallLength),startPos.z),Quaternion.identity);
					tc.roomValue =grid[i,j];
					tc.ConnectRoom();
				}
			}
		}
	}
}
