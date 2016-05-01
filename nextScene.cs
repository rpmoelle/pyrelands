using UnityEngine;
using System.Collections;

public class nextScene : MonoBehaviour {
    public AudioSource audio;
    public AudioSource waves;
    bool fade;

	// Use this for initialization
	void Start () {
	
	}
	
    void fadeAudio()
    {
        fade = true;
    }
    void next()
    {
        Application.LoadLevel(3);
    }
	// Update is called once per frame
	void Update () {
        if (fade && audio.volume > 0f)
        {
            audio.volume = audio.volume - .002f;
            waves.volume = audio.volume - .003f;
        }
	}
}
