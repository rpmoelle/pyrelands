using UnityEngine;
using System.Collections;

public class narrativeDriver : MonoBehaviour {
    public bool hasArms;
    public bool hasGoo;
    public bool fadeInOrigStone;
    GameObject o;

	// Use this for initialization
	void Start () {
        hasArms = false;
        hasGoo = false;
        o = GameObject.Find("originalsStone");
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeInOrigStone && o.GetComponent<SpriteRenderer>().color.a < 1f)
        {
           
            o.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, o.GetComponent<SpriteRenderer>().color.a + .005f);
        }
	}
}
