using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DigifestPlayer : MonoBehaviour {

    public int health = 100;

    public Bullet playerBullet;
    public Transform gun;

	// Use this for initialization
	void Start () {
        health = PlayerPrefs.GetInt("Current Health");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("roomControl"))
        {
            col.gameObject.GetComponentInParent<RoomPopulator>().AlertRoom();
        }

        //hit by bullet
        if (col.tag.Equals(Names.playerBullet))
        {
            OnDamage(col.GetComponent<Bullet>().damage);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Collider col = collision.collider;
        //exit
        if (col.tag.Equals("exit"))
        {
            PlayerPrefs.SetInt("Current Health", health);
            PlayerPrefs.SetInt(Names.currentFloor, PlayerPrefs.GetInt(Names.currentFloor) + 1);
            SceneManager.LoadScene("TheDungeon");
        }

        
    }

    void Shoot()
    {
        
        Bullet bullet = (Bullet)Instantiate(playerBullet, gun.position, gun.rotation); 
        bullet.Fly(gun.transform.forward);
    }

    void OnDamage(int damage)
    {
        health -= damage;
    }

}
