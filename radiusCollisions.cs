using UnityEngine;
using System.Collections;

public class radiusCollisions : MonoBehaviour {
    public bool collid;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        collid = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col);
        collid = false;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
