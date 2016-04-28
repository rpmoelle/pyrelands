using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {
    public GameObject dot;
    int waitCycles = 60;
    int curWait = 0;
    bool moveDot;
    Vector2 defaultDest = new Vector2(-3.89f, -0.77f);
    public GameObject navBounds;
    public bool inBounds;
    GameObject player;
    public bool disable;
   
	// Use this for initialization
	void Start () {
        inBounds = true;
        //dot = this.gameObject;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !disable)
        {
            curWait++;
            //if there's a click
            //cast a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //grab what the ray hit
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            //if it hits this object
            if (!hit && (curWait >= waitCycles))
            {
                //if player isn't clicking on anything, then they want to teleport 
                //play transition to dot anim
                //make dot visible
                Debug.Log("TELEPORTING");
                dot.GetComponent<SpriteRenderer>().color = new Color(dot.GetComponent<SpriteRenderer>().color.r, dot.GetComponent<SpriteRenderer>().color.g, dot.GetComponent<SpriteRenderer>().color.b, 1f);
                //move the dot with the cursor
                moveDot = true;
            }
            }
        if (moveDot)
        {
            
            //move the dot with the cursor
            dot.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(dot.transform.position.z != -1f)
            {
                dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, -1f);
            }
        }

        if (Input.GetMouseButtonUp(0)&& (curWait>=waitCycles))
        {
            //player released the mouse button
            //they want to teleport here
            if (inBounds)
            {
               
                this.transform.position = dot.transform.position;
                //make dot invisible
                dot.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
                curWait = 0;
                moveDot = false;
                inBounds = true;
            }
            else
            {
                
                //not in bounds
                //take player to the default location, the ocustone
                //this.transform.position = defaultDest;
                player.gameObject.transform.position = new Vector3(defaultDest.x, defaultDest.y, 0f);
               // Debug.Log(this.gameObject.transform.position);
                //make dot invisible
                dot.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                curWait = 0;
                moveDot = false;
                inBounds = true;
            }
        }
	}
}
