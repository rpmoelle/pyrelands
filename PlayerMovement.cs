using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //This moves the player around and handles animation behavior

    //Scene assets
    GameObject player;
    Animator reydoAnim;
    Animator oodaaqAnim;
    AudioSource walking;
   
    //Scene logic
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
    }

    // Use this for initialization
    void Start () {
        player = this.gameObject;
        player.GetComponent<Rigidbody2D>().freezeRotation = true;
        reydoAnim = GameObject.Find("Player/Reydo").GetComponent<Animator>();
        oodaaqAnim = GameObject.Find("Player/Oodaaq").GetComponent<Animator>();
        walking = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //ESCAPE TO "MENU"
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        //Four way motion
        if (Input.GetKey(KeyCode.W))
        {
            //Move player "UP"
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + .02f);
            //Animator transition
            //Reydo
            reydoAnim.SetBool("walkUp", true);
            reydoAnim.SetBool("walkLeft", false);
            reydoAnim.SetBool("walkDown", false);
            reydoAnim.SetBool("walkRight", false);
            //Oodaaq
            oodaaqAnim.SetBool("walkUp", true);
            oodaaqAnim.SetBool("walkLeft", false);
            oodaaqAnim.SetBool("walkDown", false);
            oodaaqAnim.SetBool("walkRight", false);
            //Play sound
            if (!walking.isPlaying)
            {
                walking.Play();
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Move player "DOWN"
            
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - .02f);
            //Animator transition
            //Reydo
            reydoAnim.SetBool("walkUp", false);
            reydoAnim.SetBool("walkLeft", false);
            reydoAnim.SetBool("walkDown", true);
            reydoAnim.SetBool("walkRight", false);
            //Oodaaq
            oodaaqAnim.SetBool("walkUp", false);
            oodaaqAnim.SetBool("walkLeft", false);
            oodaaqAnim.SetBool("walkDown", true);
            oodaaqAnim.SetBool("walkRight", false);
            //Play sound
            if (!walking.isPlaying)
            {
                walking.Play();
            }

        }
       else if (Input.GetKey(KeyCode.A))
        {
            //Move player "LEFT"
            player.transform.position = new Vector2(player.transform.position.x - .02f, player.transform.position.y);
            //Animator transition
            //Reydo
            reydoAnim.SetBool("walkUp", false);
            reydoAnim.SetBool("walkLeft", true);
            reydoAnim.SetBool("walkDown", false);
            reydoAnim.SetBool("walkRight", false);
            //Oodaaq
            oodaaqAnim.SetBool("walkUp", false);
            oodaaqAnim.SetBool("walkLeft", true);
            oodaaqAnim.SetBool("walkDown", false);
            oodaaqAnim.SetBool("walkRight", false);
            //Play sound
            if (!walking.isPlaying)
            {
                walking.Play();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Move player "RIGHT"
            player.transform.position = new Vector2(player.transform.position.x + .02f, player.transform.position.y);
            //Animator transition
            //Reydo
            reydoAnim.SetBool("walkUp", false);
            reydoAnim.SetBool("walkLeft", false);
            reydoAnim.SetBool("walkDown", false);
            reydoAnim.SetBool("walkRight", true);
            //Oodaaq
            oodaaqAnim.SetBool("walkUp", false);
            oodaaqAnim.SetBool("walkLeft", false);
            oodaaqAnim.SetBool("walkDown", false);
            oodaaqAnim.SetBool("walkRight", true);
            //Play sound
            if (!walking.isPlaying)
            {
                walking.Play();
            }
        }
        else
        {
            //no input this frame
            //play idle animation
            //Reydo
            reydoAnim.SetBool("walkUp", false);
            reydoAnim.SetBool("walkLeft", false);
            reydoAnim.SetBool("walkDown", false);
            reydoAnim.SetBool("walkRight", false);
            //Oodaaq
            oodaaqAnim.SetBool("walkUp", false);
            oodaaqAnim.SetBool("walkLeft", false);
            oodaaqAnim.SetBool("walkDown", false);
            oodaaqAnim.SetBool("walkRight", false);
            //turn off sound
            if (walking.isPlaying)
            {
                walking.Stop();
            }
        }
    }
}
