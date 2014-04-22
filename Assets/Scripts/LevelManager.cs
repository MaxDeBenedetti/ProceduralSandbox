using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int[,] grid;
	public int gridWidth, gridHeight;
	public TextMesh displayzors;
	public int numOfRooms;

	// Use this for initialization
	void Start () {
		grid = new int[gridWidth,gridHeight];
		for(int i =0; i < gridWidth; i++){
			for(int j = 0; j < gridHeight; j++){
				grid[i,j] =0;
			}
		}

		int firstX = gridWidth/2;
		int firstY = gridHeight/2;

		grid[firstX,firstY] =1;

		RoomAdder adder = new RoomAdder(firstX,firstY,grid,numOfRooms);
		int[] room;
		while(adder.RoomCount < numOfRooms){
			room = RoomAdder.PickRoom(adder.RoomCount,adder.RoomList);
			NeighborCheck(grid,room[0],room[1],adder);
			adder.Process();
		}

		displayzors.text =sayArray();

		RoomEvaluator eval = new RoomEvaluator(grid, numOfRooms);

		for(int i =0; i < gridWidth; i++){
			for(int j = 0; j < gridHeight; j++){
				if(grid[i,j] !=0){
					eval.AddCenter(i,j);
					NeighborCheck(grid,i,j,eval);
					eval.Process();
				}
			}
		}





	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NeighborCheck(int[,] grid, int row, int colum, ProcessObject p){
		if(row - 1 >=0)
			p.AddNeighbor(row-1, colum);
		if(row+1 < gridWidth)
			p.AddNeighbor(row+1, colum);
		if(colum -1 >= 0)
			p.AddNeighbor(row, colum-1);
		if(colum +1 < gridHeight)
			p.AddNeighbor(row, colum+1);
	}

	private string sayArray(){
		string array = "";
		for(int i =0; i < gridWidth; i++){
			for(int j = 0; j < gridHeight; j++){
				array += grid[i,j];
			}
			array += "\n";
		}
		return array;
	}
}
