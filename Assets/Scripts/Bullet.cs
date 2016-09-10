using UnityEngine;
using System.Collections;

[RequireComponent( typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    public int damage;
    public float flightSpeed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //requires a nomralized vector
    public void Fly(Vector3 direction)
    {
        rb.velocity = direction * flightSpeed;
    }

    public void Explode()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
