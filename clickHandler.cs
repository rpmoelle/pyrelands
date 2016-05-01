using UnityEngine;
using System.Collections;

public class clickHandler : MonoBehaviour {
    //code is adapted from: http://gamedev.stackexchange.com/questions/82928/2d-detect-mouse-click-on-object-with-no-script-attached

    public ParticleSystem ps;
    public SpriteRenderer glow;
    public SpriteRenderer rings;
    public Animator bloomer;
    Animation bow;
    Animation bloom;
    public Animator oodaaq;
    public Animator reydoAnimator;
    public SpriteRenderer reydo;
    SpriteRenderer me;
    public SpriteRenderer closeUp;
    bool showingClose;
    bool haveBowed;
   // public Animation reveal;
   // public Animation idle;
    //public GameObject player;
    bool fadein;
    bool hasAppeared;
    bool noClick;
    public GameObject narrativeDriver;
    public bool isAnim;
    public bool isVisible;
    public string finishedAnim;
    bool wept;
    GameObject player;
    bool moveDot;
    public Vector2 dest;
    public Vector2 boatDest;
    bool teleBoat;
    bool teleOrig;
    bool playingUntie;
    bool playingWeep;
    public Animator boat;
    bool playingEnd;
    public Animator title;
    bool last;
    bool clicked;
    public GameObject fader;
    public GameObject radius;

    void endScene()
    {
        //just an animation for the scene
        //boat
        playingEnd = true;
        boat.SetTrigger("endtrig");
        //reydo and oodaaq
        reydoAnimator.SetBool("end", true);
        oodaaq.SetBool("end", true);
    }

    void teleport(Vector2 d)
    {
       //disable hold to click teleporting
        if(d == dest)
        {
            teleOrig = true;
            //teleBoat = false;
        }
        if(d == boatDest)
        {
           
            teleBoat = true;
            //teleOrig = false;
        }
        //plays teleport animation by itself
        if (!moveDot)
        {
            player.GetComponent<teleport>().disable = true;
            Debug.Log("teleporting");
            //fade out idle sprite
            Transform r = player.transform.Find("Reydo");
            Transform o = player.transform.Find("Oodaaq");
            r.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            o.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            //make teleport dot visible
            //Transform tele = player.transform.Find("teleporter");
            //tele.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            //move teleport dot (in update)
           // moveDot = true;
        }
        else
        {
            //player.GetComponent<teleport>().disable = false;
            Debug.Log("stop");
            //we have arrived
            //fade out idle sprite
            Transform r = player.transform.Find("Reydo");
            Transform o = player.transform.Find("Oodaaq");
            r.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            o.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            //make teleport dot visible
            //Transform tele = player.transform.Find("teleporter");
            //tele.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            //move teleport dot (in update)
            moveDot = false;
            //play anim
            if (teleOrig)
            {
                reydoAnimator.SetBool("weep", true);
                oodaaq.SetBool("weep", true);
                playingWeep = true;
            }
            else if (teleBoat && !(narrativeDriver.GetComponent<narrativeDriver>().hasGoo))
            {
                Debug.Log("CANT DO THAT");
                //reydoAnimator.SetBool("cant", true);
                //oodaaq.SetBool("cant", true);
                reydoAnimator.SetTrigger("untie");
                oodaaq.SetTrigger("untie");
                teleBoat = false;
                playingUntie = true;
            }
            else if(teleBoat && (narrativeDriver.GetComponent<narrativeDriver>().hasGoo))
            {
                //escape!
                Debug.Log("escape");
                reydoAnimator.SetBool("leave", true);
                oodaaq.SetBool("leave", true);
                //dissolve rope
                GameObject.Find("rope").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                endScene();
            }
        }

    }
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
       // bloomer = GameObject.Find("prophetStone/prophetsBloom").GetComponent<Animator>();
        oodaaq = GameObject.Find("Player/Oodaaq").GetComponent<Animator>();
        reydoAnimator = GameObject.Find("Player/Reydo").GetComponent<Animator>();
        reydo = GameObject.Find("Player/Reydo").GetComponent<SpriteRenderer>();
        //bloom = bloomer.GetComponent<Animation>();
        me = this.gameObject.GetComponent<SpriteRenderer>();
        narrativeDriver = GameObject.Find("narrativeDriver");
        dest = new Vector2(4.51f, -5.51f);
        fader = GameObject.Find("Title/Letters/fader");
        //this avoids having to click twice to see the pullout image for stones without bloom anims
        if (!isAnim)
        {
            hasAppeared = true;
        }
        if(this.gameObject.name == "originalsStone" || this.gameObject.name == "exitStone")
        {
            hasAppeared = false;
        }
    }
	
    /*bool canUntie()
    {
        Debug.Log("Untie");
        if(narrativeDriver.GetComponent<narrativeDriver>().hasGoo)
        {
            return true;
        }
        return false;
    }*/

	// Update is called once per frame
	void Update () {
        
      
       
        if (playingEnd && boat.gameObject.transform.localScale.x < .5f)
        {
            Debug.Log("fadeOut");
            title.SetTrigger("fadeOut");
            playingEnd = false;
            last = true;
            
        }
        if(last && fader.gameObject.GetComponent<SpriteRenderer>().color.a < 1f)
        {
            Debug.Log("DOND");
            last = false;
            
            //Application.LoadLevel(2);
        }
        if (moveDot)
        {
            //player is automatically teleporting
            if (teleOrig)
            {
                player.transform.position = new Vector3(dest.x, dest.y, -2f);
                teleport(dest);
            }
            else
            {
                Debug.Log("going to boat " + player.transform.position);
                player.transform.position = new Vector3(boatDest.x, boatDest.y, -2f);
                teleport(boatDest);
            }
            //Find X distance to dest
            /*float xdist = dest.x-player.transform.position.x;
            //Find Y distance to dest
            float ydist = dest.y - player.transform.position.y;
            //move player towards dest
                player.transform.position = new Vector3(dest.x - xdist, dest.y + ydist, -2f);*/
            
        }

        
      

        if (playingWeep && !reydoAnimator.GetCurrentAnimatorStateInfo(0).IsName("reydoIdle"))
        {
            
            //reset anims
            
            reydoAnimator.SetBool("doneWeep", true);
            reydoAnimator.SetBool("weep", false);
            oodaaq.SetBool("weep", false);
            playingWeep = false;
            player.GetComponent<teleport>().disable = false;

        }

       if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if (showingClose)
            {
                Debug.Log("Closing close up");
                closeUp.color = new Color(closeUp.color.r, closeUp.color.g, closeUp.color.b, 0f);
                showingClose = false;
                if (isAnim)
                {
                    //play animation
                    fadein = true;
                    
                    if(this.gameObject.name == "originalsStone")
                    {
                        Debug.Log("At originals stone");
                        if (this.gameObject.GetComponent<SpriteRenderer>().color.a > 0f)
                        {
                            Debug.Log("HAVE GOO");
                            narrativeDriver.GetComponent<narrativeDriver>().hasGoo = true;
                            reydoAnimator.SetBool("weep", true);
                            oodaaq.SetBool("weep", true);
                            playingWeep = true;
                        }
                        
                    }
                    else if(this.gameObject.name == "exitStone")
                    {
                        if (this.gameObject.name == "exitStone" && !(narrativeDriver.GetComponent<narrativeDriver>().hasGoo))
                        {
                            Debug.Log("CANT DO THAT");
                            //reydoAnimator.SetBool("cant", true);
                            //oodaaq.SetBool("cant", true);
                            reydoAnimator.SetTrigger("untie");
                            oodaaq.SetTrigger("untie");

                            playingUntie = true;
                        }
                        else if (this.gameObject.name == "exitStone" && (narrativeDriver.GetComponent<narrativeDriver>().hasGoo))
                        {
                            //escape!
                            Debug.Log("escape");
                            reydoAnimator.SetBool("leave", true);
                            oodaaq.SetBool("leave", true);
                            //dissolve rope
                            GameObject.Find("rope").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                            endScene();
                        }
                    }
                    else
                    {
                        bloomer.SetTrigger("bloomTrig");
                    }
                    
                  
                }
            }
           else if (radius != null && radius.GetComponent<radiusCollisions>().collid)
            {
                
                if (!showingClose && (gameObject.name != "originalsStone"))
                {
                    
                    closeUp.color = new Color(closeUp.color.r, closeUp.color.g, closeUp.color.b, 1f);
                    showingClose = true;
                   // clicked = true;
                }
                else if(!showingClose && (gameObject.name == "originalsStone"))
                {
                    if(this.gameObject.GetComponent<SpriteRenderer>().color.a > 0f)
                    {
                        Debug.Log("Close up now showing");
                        closeUp.color = new Color(closeUp.color.r, closeUp.color.g, closeUp.color.b, 1f);
                        showingClose = true;
                    }
                }
            }
        }

       /* if (Input.GetMouseButtonDown(0))
        {
            
            //if there's a click
            //cast a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //grab what the ray hit
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            //if it hits this object
            if (hit)
            {
                if (hit.collider.gameObject.name == this.name)
                {
                    if (this.name == "exitStone")
                    {
                        //teleport here
                        teleport(boatDest);
                        //Debug.Log("boat dest is)" + boatDest);
                    }

                    if (this.name == "originalsStone")
                    {
                        //this is the player attempting to lube arms
                        //wept = true;
                        
                        //teleport player to the stone if they arent there already
                        teleport(dest);
                        //play weep
                       // oodaaq.SetBool("doneBowing", true);
                       // reydoAnimator.SetBool("weep", true);
                    }

                    if (hit.collider.gameObject.name == "prophetStone")
                    {
                        narrativeDriver.GetComponent<narrativeDriver>().hasArms = true;
                        //Debug.Log(narrativeDriver.GetComponent<narrativeDriver>().hasArms + "ARMS");
                    }
                    else if (this.gameObject.name == "originalsStone")
                    {
                        narrativeDriver.GetComponent<narrativeDriver>().hasGoo = true;
                        //Debug.Log(narrativeDriver.GetComponent<narrativeDriver>().hasGoo + "GOO");
                    }

                    //play the bloom animation for these characters, if they havent appeared yet
                    if (isAnim && this.gameObject.name != "exitStone")
                    {
                        Debug.Log("ANIMATING NOW");
                       // ps.Play();
                        fadein = true;
                        bloomer.SetTrigger("bloomTrig");
                        //bloomer.SetBool("bloom", true);
                        //these characters have appeared, after animation cascade, don't reeappear
                        //hasAppeared = true;
                       // bloomer.SetBool("reveal", true);
                       // bloomer.SetBool("fade", true);
                        //cancel click mechanics while playing animation
                        //noClick = true;
                    }
                    //show the close up instead of the animation
                    
                   /* else if (hasAppeared && showingClose)
                    {
                        closeUp.color = new Color(closeUp.color.r, closeUp.color.g, closeUp.color.b, 0f);
                        showingClose = false;
                    }
                }
              
            } 
        }*/
        //begin fading in the glow
        if (fadein && glow.color.a < 1)
        {
            rings.color = new Color(rings.color.r, rings.color.g, rings.color.b, rings.color.a + .007f);
            //glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, glow.color.a + .007f);
        }
        else if (fadein)
        {
            fadein = false;
        }

        if (isAnim && (this.gameObject.name != "originalsStone" && this.gameObject.name != "exitStone"))
        {
            if (this.bloomer.GetCurrentAnimatorStateInfo(0).IsName(finishedAnim) && !haveBowed)
            {
                Debug.Log(gameObject.name);
                //reydo.color = new Color(reydo.color.r, reydo.color.g, reydo.color.b, 0f);
                oodaaq.SetBool("bow", true);
                haveBowed = true;
                //oodaaq.SetBool("returnIdle", true);
                oodaaq.SetBool("doneBowing", true);
                reydoAnimator.SetBool("reybow", true);
                reydoAnimator.SetBool("doneBowing", true);
                //Debug.Log("reydoanimator" + reydoAnimator.GetBool("reybow"));
                //reydoAnimator.SetBool("doneBowing", true);

                //This is a plot advance
                if(this.gameObject.name == "prophetStone")
                {
                    narrativeDriver.GetComponent<narrativeDriver>().hasArms = true;
                    Debug.Log(narrativeDriver.GetComponent<narrativeDriver>().hasGoo + "ARMS");
                }
                else if(this.gameObject.name == "oseyeStone")
                {
                    //make the originals stone visible
                    GameObject o = GameObject.Find("originalsStone");
                    narrativeDriver.GetComponent<narrativeDriver>().fadeInOrigStone = true;
                    o.GetComponent<PolygonCollider2D>().enabled = true;
                }
                /*else if(this.gameObject.name == "originalsStone")
                {
                    narrativeDriver.GetComponent<narrativeDriver>().hasGoo = true;
                    Debug.Log(narrativeDriver.GetComponent<narrativeDriver>().hasGoo + "GOO");
                }*/
            }
            /*if (haveBowed && !oodaaq.GetCurrentAnimatorStateInfo(0).IsName("bowAnim"))
            {
                //Debug.Log("currently not bowing and I have bowed");
                //oodaaq.SetBool("bow", false);
            }*/
            if (oodaaq.GetCurrentAnimatorStateInfo(0).IsName("oodaaqBow"))
            {
                // Debug.Log("HELP");
                oodaaq.SetBool("bow", false);
                reydoAnimator.SetBool("reybow", false);
                // reydo.color = new Color(reydo.color.r, reydo.color.g, reydo.color.b, 1f);
            }
            if (reydoAnimator.GetCurrentAnimatorStateInfo(0).IsName("reydoBow"))
            {
                //oodaaq.SetBool("bow", false);
            }
        }
        /*else if(haveBowed)
        {
            Debug.Log("FUCK" + haveBowed);
            //oodaaq.SetBool("bow", false);
           //oodaaq.SetBool("doneBowing", true);
        }*/
        if (playingUntie && !reydoAnimator.GetCurrentAnimatorStateInfo(0).IsName("reydoCantUntie"))
        {
            Debug.Log("should reset" + !reydoAnimator.GetCurrentAnimatorStateInfo(0).IsName("reydoCantUntie"));
            //reset anims
            //teleBoat = false;
            //reydoAnimator.SetBool("doneCant", true);
            //reydoAnimator.SetBool("cant", false);
            //oodaaq.SetBool("cant", false);
            playingUntie = false;

        }

    }
}
