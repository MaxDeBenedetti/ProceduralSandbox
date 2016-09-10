using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomPopulator : MonoBehaviour {

    public List<Transform> spawnLocations = new List<Transform>();
    public List<Spawnable> spawnables = new List<Spawnable>();

    private List<EnemyActor> enemies = new List<EnemyActor>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Populate()
    {
        foreach(Transform t in spawnLocations)
        {
            enemies.Add(GameObject.Instantiate(spawnables[0]).GetComponent<EnemyActor>());
            enemies[enemies.Count - 1].transform.position = t.position;
        }
    }

    public void AlertRoom()
    {
        Debug.Log("room alerted");
        foreach(EnemyActor ea in enemies)
        {
            ea.seekingPlayer = true;
        }
    }


}
