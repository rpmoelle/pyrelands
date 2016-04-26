using UnityEngine;
using System.Collections;

public class ocuStoneGlow : MonoBehaviour {
    public SpriteRenderer rings;
    public SpriteRenderer glow;
    bool fadein;
    bool fadeout;

    void OnTriggerEnter2D(Collider2D col)
    {
        //if the player steps on the ocustone, gradually make it glow
        if(col.gameObject.name == "Player")
        {
            fadein = true;
            fadeout = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //if the player steps out of the ocustone, make it gradually stop glowing
        if(col.gameObject.name == "Player")
        {
            fadeout = true;
            fadein = false;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if it is time to fade in, fade in the rings
        if (fadein && rings.color.a < 1)
        {
            rings.color = new Color(rings.color.r, rings.color.g, rings.color.b, rings.color.a + .007f);
            glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, glow.color.a + .007f);
        }
        else if (fadein)
        {
            fadein = false;
        }
        else if (fadeout && rings.color.a > 0)
        {
            rings.color = new Color(rings.color.r, rings.color.g, rings.color.b, rings.color.a - .007f);
            glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, glow.color.a - .007f);
        }
        else if (fadein)
        {
            fadeout = false;
        }
    }
}
