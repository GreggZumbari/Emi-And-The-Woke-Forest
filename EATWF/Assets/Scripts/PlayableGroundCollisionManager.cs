/**
 * This class can be attached to the "feet" of any moving GameObject that will be able to double jump.
 * This class updates the boolean variable "bool midAir" to show whether the GameObject that the feet are attached to is mid-air or not on that frame.
 * @author Greggory Hickman, October 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableGroundCollisionManager : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject; //Init player as the parent of the current GameObject
    }

    void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<PlayableMovementManager>().midAir = false; //When the feet touch the ground, set midAir to false
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayableMovementManager>().midAir = true; //When the feet leave the ground, set midAir to true
    }
}