using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private DigifestPlayer me;
    public Image health100, health10, health1, healthIndicator;
    public Sprite[] numbers = new Sprite[10];
    public Sprite midHealth, lowHealth;
    

	// Use this for initialization
	void Start () {
        me = gameObject.GetComponent<DigifestPlayer>();
        UpdateHealth();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //breaks a three digit number into its digits
    public int[] Digits(int number)
    {
        int[] digits = new int[3];
        digits[2] = number % 10;
        number /= 10;
        digits[1] = number % 10;
        number /= 10;
        digits[0] = number;
        return digits;
    }

    public void UpdateHealth()
    {
        int[] digits;
        if (me.health >= 0)
        {
            digits = Digits(me.health);
        }
        else
        {
            digits = new int[3] { 0, 0, 0 };
        }
        health100.sprite = numbers[digits[0]];
        health10.sprite = numbers[digits[1]];
        health1.sprite = numbers[digits[2]];
        if (me.health < 50)
            healthIndicator.sprite = midHealth;
        if (me.health < 15)
            healthIndicator.sprite = lowHealth;
    }
}
