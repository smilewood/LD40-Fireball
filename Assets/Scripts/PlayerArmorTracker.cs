using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmorTracker : MonoBehaviour {
    public int armor;
	// Use this for initialization
	void Start () {
        ChangeArmor(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public MenuButtonActions menu;
    public Text text;
    public string words;
    public void ChangeArmor(int ammount)
    {
        if (armor + ammount > 100)
        {
            armor = 100;
        }
        
        else
        {
            armor += ammount;
        }
        text.text = words + " " + armor;
        if (armor <= 0)
        {
            menu.GameOver();
            this.gameObject.GetComponent<PlayerConrtoller>().enabled = false;
        }
        float speedoffset = (armor * .01f) * 10;
        this.gameObject.GetComponent<PlayerConrtoller>().speed = 11 - speedoffset;
    }
}
