using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour {

    public CanvasGroup cg;
    public float duration = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeFlash()
    {
        StopAllCoroutines();
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        cg.alpha = 1;
        yield return new WaitForSeconds(duration);
        cg.alpha = 0;
    }
}
