using UnityEngine;
using System.Collections;

public class fadeOut : MonoBehaviour {

    public SpriteRenderer fader;
    bool fadedOut;
    bool fadeIn;

	// Use this for initialization
	void Start () {
        fader = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
      
        if(!fadedOut && fader.color.a > 0f)
        {
            //this is the fade in that plays on entry ot the scene
            Debug.Log(fader.color.a);
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, fader.color.a - .005f);
            if (fader.color.a <= .006)
            {
                //check if you should fadeOut
                Debug.Log("asldfkjnalskdjvqlkjfd");
                fadedOut = true;
            }
        }
        Debug.Log("here");
        //If player clicks, fade out to next scene
        if (fadedOut)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("ppop");
                fadeIn = true;
            }
        }
        //fade in, then go to next scene
        if (fadeIn && fader.color.a < 1f)
        {
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, fader.color.a + .005f);
            if(fader.color.a == 1f)
            {
                //if its faded in, load next scene
                Application.LoadLevel(1);
            }
        }
	}
}
