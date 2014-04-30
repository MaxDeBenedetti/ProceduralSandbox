using UnityEngine;
using System.Collections;

public class LevelManager2 : MonoBehaviour
{
	
	public int[,] grid;
	public int gridWidth, gridHeight;
	public TestCube cub;
	public int numOfRooms;
	public int roomLength, hallLength;
	public GameObject player;
	
	
	// Use this for initialization
	void Start()
	{
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
		
		grid[firstX, firstY] = 1;
		
		RoomAdder adder = new RoomAdder(firstX, firstY, grid, numOfRooms);
		int[] room;
		while (adder.RoomCount < numOfRooms)
		{
			room = RoomAdder.PickRoom(adder.RoomCount, adder.RoomList);
			NeighborCheck(grid, room[0], room[1], adder);
			adder.Process();
		}
		
		RoomEvaluator eval = new RoomEvaluator(grid, numOfRooms);
		
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
		
		
		roomify();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	/*
	 * checks the rooms around a specified room and then performs the action defined by process object p
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
		//Instantiate(cub,startPos,Quaternion.identity);
		bool playerNotAdded = true;
		TestCube tc;
		for(int i =0; i < gridWidth; i++){
			for(int j=0; j <gridHeight; j++){
				
				if(grid[i,j] != 0){
					if(playerNotAdded)
						player.rigidbody.position = new Vector3(startPos.x+j,startPos.y-i,-2f);
					tc = (TestCube)Instantiate(cub,new Vector3(startPos.x+j,startPos.y-i,startPos.z),Quaternion.identity);
					tc.setNum(grid[i,j]);
				}
			}
		}
	}
}
