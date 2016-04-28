using UnityEngine;
using System.Collections;

public class creditsController : MonoBehaviour {
    public Animator anim;
    public AudioSource audio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(audio.volume < 1f)
        {
            //fade in
            audio.volume = audio.volume + .05f;
        }
	}
}
