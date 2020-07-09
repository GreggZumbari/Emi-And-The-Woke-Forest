/**
 * This class will add a custom friction effect to any entity. 
 * @author Greggory Hickman, October 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public bool disableFriction; //Enable or disable the friction effect, false means that friction is enabled
    public bool isPlayable; //If the current entity is a playable character
    public float playerFrictionCoefficient; //The percentage of retained velocity after each frame when no other forces are acting on THE PLAYER
    public float frictionCoefficient; //The percentage of retained velocity after each frame when no other forces are acting on AN ENTITY

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Friction!
         */
        //If friction is enabled for this GameObject
        if (!disableFriction)
        {
            //If current GameObject is a playable character
            if (isPlayable)
            {
                //If not moving anymore, slide and stop
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(playerFrictionCoefficient * GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
                }
            }
            //If current GameObject is NOT a playable character
            else
            {
                //Every frame, slightly reduce the x velocity
                GetComponent<Rigidbody>().velocity = new Vector3(frictionCoefficient * GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
            }
        }
    }
}
