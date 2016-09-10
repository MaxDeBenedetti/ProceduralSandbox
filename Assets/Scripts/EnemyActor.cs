using UnityEngine;
using System.Collections;

public class EnemyActor : Spawnable {

    public bool seekingPlayer = false;
    public int health, damage;
    public Bullet enemybullet;
    public Transform gun, gunBase;
    private Transform playerPosition;

	// Use this for initialization
	void Start () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        health = PlayerPrefs.GetInt(Names.currentFloor);
        damage = health;//hacky
	}
	
	// Update is called once per frame
	void Update () {
        gunBase.transform.LookAt(playerPosition);
	}

    public void Shoot()
    {
        Bullet bullet = (Bullet)Instantiate(enemybullet, gun.position, gun.rotation);
        bullet.Fly(gunBase.transform.forward);

    }

    void OnTrigerEnter(Collider col)
    {
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
