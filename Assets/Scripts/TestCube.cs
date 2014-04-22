using UnityEngine;
using System.Collections;

public class TestCube : MonoBehaviour {

    public TextMesh dis;
    public int num;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setNum(int newNum)
    {
        num = newNum;
        dis.text="" + num;
    }
}
