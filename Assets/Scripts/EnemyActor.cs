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
    public Sprite drawn, fire, dead;
    public SpriteRenderer mySprite;
    public AudioSource shotSound, deathSound;

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
        shotSound.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.tag.Equals(Names.playerBullet))
        {
            OnDamage(col.GetComponent<Bullet>().damage);
            col.GetComponent<Bullet>().MakeExplode();
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
            mySprite.sprite = drawn;
            isReadyToShoot = false;
            StartCoroutine("Shooting");
        }
    }

    IEnumerator Shooting()
    {
        while (true) {
            float delay = Random.Range(0.05f, 3f);
            yield return new WaitForSeconds(delay);
            mySprite.sprite = fire;
            Shoot();
            yield return new WaitForSeconds(0.2f);
            mySprite.sprite = drawn;
        }
    }

    void Die()
    {
        StopAllCoroutines();
        isAlive = false;
        PlayerPrefs.SetInt(Names.currentKills, PlayerPrefs.GetInt(Names.currentKills) + 1);
        mySprite.sprite = dead;
        deathSound.Play();
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Collider[] cols  = gameObject.GetComponentsInChildren<Collider>();
        for(int i = 0; i < cols.Length; i++)
        {
            cols[i].enabled = false;
        }
    }

 }
