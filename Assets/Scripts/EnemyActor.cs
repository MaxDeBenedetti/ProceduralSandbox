using UnityEngine;
using System.Collections;

public class EnemyActor : Spawnable {

    public bool seekingPlayer = false;
    public int health, damage;
    public Bullet enemybullet;
    public Transform gun;
    public Transform playerPosition;

	// Use this for initialization
	void Start () {
        playerPosition = GameObject.FindGameObjectWithTag("player").transform;
        health = PlayerPrefs.GetInt(Names.currentFloor);
        damage = health;//hacky
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Shoot()
    {
        GameObject nObject = (GameObject)GameObject.Instantiate(enemybullet, gun.position, gun.rotation);
        Bullet bullet = nObject.GetComponent<Bullet>();
        bullet.Fly(gun.transform.forward);

    }

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if (col.tag.Equals(Names.playerBullet))
        {
            OnDamage(col.GetComponent<Bullet>().damage);
        }
    }

    void OnDamage(int damage)
    {
        health -= damage;
    }
 }
