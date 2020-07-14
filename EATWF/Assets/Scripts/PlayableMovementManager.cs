/**
 * Manages all moving capabilies for the current playable character.
 * Meant to be run on the hitbox of the character.
 * @author Greggory Hickman, October 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableMovementManager : MonoBehaviour
{
    //These must be defined manually in the inspector
    public GameObject camera; //The player's view
    public GameObject umbrella; //Just a sprite basically
    public GameObject beatsPill; //This is simply the object which holds the Sound Effect Manager

    public float speed;
    public float jumpMagnitude;
    public float slowFallMult;

    public int multiJumpLimit; //Number of jumps in between rests
    public int airJumps;

    public bool midAir;

    private SoundEffectManager sem;

    // Start is called before the first frame update
    void Start()
    {
        camera.GetComponent<Camera>().orthographic = true; //Set player view to be orthographic by default
        GetComponent<Rigidbody>().isKinematic = false; //Kinematic = bad
        umbrella.GetComponent<SpriteRenderer>().enabled = false; //Disable umbrella icon by default

        midAir = true;

        sem = beatsPill.GetComponent<SoundEffectManager>();

        speed = 7;
        jumpMagnitude = 14;
        slowFallMult = 1;
        multiJumpLimit = 1;
        airJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Movement (left and right only)
         * Press A or D to move
         */
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(-GetComponent<Transform>().right * Time.deltaTime * speed);
            GetComponent<Rigidbody>().velocity = new Vector3(-speed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(GetComponent<Transform>().right * Time.deltaTime * speed);
            GetComponent<Rigidbody>().velocity = new Vector3(speed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        /**
         * Jumping
         * Press Space to jump
         */
        if (Input.GetKeyDown(KeyCode.Space) && (airJumps < multiJumpLimit || !midAir)) //If space is pressed, and the player still has some air jumps left or if the player is on the ground
        {
            sem.a_playerJump(GetComponent<AudioSource>());
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpMagnitude, GetComponent<Rigidbody>().velocity.z);
            airJumps++;
        }
        if (!midAir)
        {
            airJumps = 0;
        }

        /**
         * Slow fall
         * Hold Space to fall slower
         */
        if (GetComponent<Rigidbody>().velocity.y <= 0 && Input.GetKey(KeyCode.Space) && midAir == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,
            GetComponent<Rigidbody>().velocity.y / (1.01f + 0.01f * slowFallMult),
            GetComponent<Rigidbody>().velocity.z);

            umbrella.GetComponent<SpriteRenderer>().enabled = true; //Pop out the umbrella
        }
        else
        {
            umbrella.GetComponent<SpriteRenderer>().enabled = false; //Put away the umbrella
        }
    }
}
