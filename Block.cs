using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {


    public Color[] BrickColors;

    private int Maxhit;
    private int Timeshit;
    bool Isbreakable;
    private LevelManager levelManager;
    public static int breakableCount = 0;


    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Timeshit = 0;
        Isbreakable = (this.tag == "Breakable");
        if (Isbreakable)
        {
            breakableCount++;
        }
        Maxhit = BrickColors.Length + 1;

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (Isbreakable)
        {
            Handlehits();
        }
        
       
    }

    void Handlehits()
    {
        Timeshit++;
        if (Timeshit >= Maxhit)
        {
            breakableCount--;
            levelManager.DestroyedBricks();
            GameObject.Destroy(gameObject);
        }else
        {
            Colorchanging();
        }
    }

    void Colorchanging()
    {
        int Colorindex = Timeshit - 1;
        this.GetComponent<SpriteRenderer>().color = BrickColors[Colorindex];
    }
}
