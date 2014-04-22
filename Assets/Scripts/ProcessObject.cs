using UnityEngine;
using System.Collections;

public interface ProcessObject{

	void AddCenter(int x, int y);
	void AddNeighbor(int x, int y);
	void Process();

}