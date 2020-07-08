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
        player.GetComponent<PlayableMovingManager>().midAir = false; //When the feet touch the ground, set midAir to false
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayableMovingManager>().midAir = true; //When the feet leave the ground, set midAir to true
    }
}