using UnityEngine;
using System.Collections;

public interface ProcessObject{

	//Determins the room that is currently being worked on
	void AddCenter(int x, int y);

	//Determins an additional neighbor to the room being worked on
	void AddNeighbor(int x, int y);

	//Decides what do with the room and its neighbors
	void Process();

}