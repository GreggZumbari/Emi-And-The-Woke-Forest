/**
 * This class will add a custom friction effect to any entity. 
 * @author Greggory Hickman, October 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public bool enableFriction; //Enable or disable the friction effect
    public bool isPlayable; //If the current entity is a playable character

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
        if (enableFriction)
        {
            //If current GameObject is a playable character
            if (isPlayable)
            {
                //If not moving anymore, slide and stop
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0.85f * GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
                }
            }
            //If current GameObject is NOT a playable character
            else
            {
                //Every frame, slightly reduce the x velocity
                GetComponent<Rigidbody>().velocity = new Vector3(0.96f * GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
            }
        }
    }
}
