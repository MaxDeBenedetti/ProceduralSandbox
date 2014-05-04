using System;
using UnityEngine;

public class RoomEvaluator:ProcessObject
{
	private int dIndex =0;
	private int[] directions = new int[] {2,5,7,3};
	private int product = 1;
	private int[,] grid;
	private int[] center;
	private int[] specialRooms;//Creates a list of rooms w/ only one adjacency. This would be useful for determining locations for boss or treasure rooms.
	private int specialRoomCount=0;

	public RoomEvaluator (int[,] grid, int numOfRooms)
	{
		this.grid = grid;
		specialRooms = new int[numOfRooms*2];
	}

	/*
	 * CheckNeighbors always adds neighbors in the order top, bottom, left, right. 
	 * We use this fact to determine the product of primes that determines a room's adjacency
	 */
	public void AddNeighbor(int x, int y){
		if(grid[x,y] !=0){//if the neighbor is a room in the maze
			product *= directions[dIndex];//directions = {2,5,7,3} 
		}
		dIndex++;
	}

	public void AddCenter(int x, int y){
		center = new int[] {x,y};
	}

	//Changes a room's value to a product of primes which can be used to determine adjacency
	public void Process(){
		grid[center[0],center[1]] = product;//changes the rooms value

		//If the room has only one adjacency this block adds the room to a special list of rooms. 
		//One adjacency rooms would be useful for determining locations for boss or treasure rooms.
		if(product < 10 && product != 6){
			int start = specialRoomCount*2;
			specialRooms[start] = center[0];
			specialRooms[start+1] = center[1];
			specialRoomCount++;
		}

		//Resets product and dIndex for the next run
		product =1;
		dIndex =0;
	}

	public int[] SpecialRoomList{
		get {return specialRooms;}
		set {specialRooms = value;}
	}

	public int SpecialRoomCount{
		get {return specialRoomCount;}
		set {specialRoomCount = value;}
	}


}


