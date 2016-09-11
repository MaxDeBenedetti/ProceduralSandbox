using UnityEngine;
using System.Collections;

public class EnemyActor : Spawnable {

    public bool seekingPlayer = false;
    public int health, damage;
    public Bullet enemybullet;
    public Transform gun, gunBase;
    private Transform playerPosition;
    private bool isAlive = true;
    private bool isReadyToShoot = true;

    // Use this for initialization
    void Start() {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        health = PlayerPrefs.GetInt(Names.currentFloor);
        damage = health;//hacky
    }

    // Update is called once per frame
    void Update() {
        gunBase.transform.LookAt(playerPosition);
    }

    public void Shoot()
    {
        Bullet bullet = (Bullet)Instantiate(enemybullet, gun.position, gun.rotation);
        bullet.damage = damage;
        bullet.Fly(gunBase.transform.forward);

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.tag.Equals(Names.playerBullet))
        {
            OnDamage(col.GetComponent<Bullet>().damage);
        }
    }

    void OnDamage(int damage)
    {
        health -= damage;
        Debug.Log("hit " + health);
        if (health < 1)
            Die();
    }

    public void StartShooting()
    {
        if (isAlive && isReadyToShoot)//enemy is alive and not already shooting
        {
            isReadyToShoot = false;
            StartCoroutine("Shooting");
        }
    }

    IEnumerator Shooting()
    {
        while (true) {
            float delay = Random.Range(0.25f, 3f);
            yield return new WaitForSeconds(delay);
            Shoot();
        }
    }

    void Die()
    {
        StopAllCoroutines();
        isAlive = false;
        PlayerPrefs.SetInt(Names.currentKills, PlayerPrefs.GetInt(Names.currentKills) + 1);
    }

 }
