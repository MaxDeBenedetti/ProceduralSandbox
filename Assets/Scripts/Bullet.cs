using UnityEngine;
using System.Collections;

[RequireComponent( typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    public int damage;
    public float flightSpeed;
    private Rigidbody rb;
    public SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr.enabled = false;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //requires a nomralized vector
    public void Fly(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction * flightSpeed;
    }

    IEnumerator Explode()
    {
        
        rb.velocity = Vector3.zero;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        sr.enabled = true;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("WallOrFloor")) 
        {
            Debug.Log(col.tag);
            StartCoroutine("Explode");
        }
    }

    public void MakeExplode()
    {
        StartCoroutine("Explode");
    }
}
