using System;
using UnityEngine;

public class RoomAdder:ProcessObject
{
	private int[,] grid;
	private int[] center;
	private int[] neighbors;
	private int[] rooms;//All rooms are stored as alternating x and y values in a single array
	private int neighborsCount = 0;
	private int roomCount = 1;

	public RoomAdder (int firstX, int firstY, int[,] grid, int numOfRooms)
	{
		this.grid = grid;
		center = new int[2];
		neighbors = new int[8];
		rooms = new int[numOfRooms*2];
		rooms[0] = firstX;
		rooms[1] = firstY;
	}

	public void AddCenter(int x, int y){
		center[0]=x;
		center[1]=y;
	}

	//Creates a list of rooms from which the next room to be added will be randomly picked
	public void AddNeighbor(int x, int y){
		if(grid[x,y] == 0){//Will only add the neighbor to the list if the neighbor's value is 0
			int start = neighborsCount *2;
			neighbors[start] = x;//All rooms are stored as alternating x and y values in a single array
			neighbors[start +1] = y;
			neighborsCount++;
		}
	}

	public void Clear(){

	}

	//Randomly picks a room from 1D room storage structures
	public static int[] PickRoom(int numOfRooms, int[] listOfRooms){
		int start = (int)(UnityEngine.Random.value * numOfRooms) *2;
		int[] room = {listOfRooms[start],listOfRooms[start+1]};
		return room;
	}

	//Changes a neighboring room's value from 0 to 1
	public void Process(){
		if(neighborsCount !=0){
			int[] newRoom = PickRoom(neighborsCount, neighbors);//Selects a random neighbor
			grid[newRoom[0],newRoom[1]] = 1;//Changes the neighbor's value to 1

			//Adds the new room to a list of rooms
			int start = roomCount * 2;
			rooms[start] = newRoom[0];
			rooms[start+1] = newRoom[1];
			roomCount++;

			neighborsCount=0;//Resets neighborsCount for the next run
		}
		
	}

	public int[] RoomList{
		get {return rooms;}
		set {rooms = value;}
	}

	public int RoomCount{
		get {return roomCount;}
		set {roomCount = value;}
	}


}


