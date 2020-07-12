/**
 * This class will contain everything concerning entity behavior, including but no limited to enemy movement AI and friendly NPC movement AI.
 * @author Greggory Hickman, July 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    public GameObject player;

    public float damageRadiusX; //Additional range of attack that the enemy has in any given direction
    public float damageRadiusY;

    public bool isHarmful;
    public bool touchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        damageRadiusX = 0.1f;
        damageRadiusY = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Detect collision with the player
         */
        //This works by comparing the player's x and y location values with this entity's x and y location values
        float playerLeft = player.GetComponent<Transform>().position.x - 0.5f * player.GetComponent<Transform>().localScale.x;
        float playerRight = player.GetComponent<Transform>().position.x + 0.5f * player.GetComponent<Transform>().localScale.x;
        float playerTop = player.GetComponent<Transform>().position.y + 0.5f * player.GetComponent<Transform>().localScale.y;
        float playerBottom = player.GetComponent<Transform>().position.y - 0.5f * player.GetComponent<Transform>().localScale.y;
        float enemyLeft = GetComponent<Transform>().position.x - 0.5f * (GetComponent<Transform>().localScale.x + damageRadiusX);
        float enemyRight = GetComponent<Transform>().position.x + 0.5f * (GetComponent<Transform>().localScale.x + damageRadiusX);
        float enemyTop = GetComponent<Transform>().position.y + 0.5f * (GetComponent<Transform>().localScale.y + damageRadiusY);
        float enemyBottom = GetComponent<Transform>().position.y - 0.5f * (GetComponent<Transform>().localScale.y + damageRadiusY);
        //< = to the left of or below, > = to the right of or above

        if (((playerLeft < enemyRight && //If player's left edge is within the x-bounds of the enemy
            playerLeft > enemyLeft) ||
            (playerRight > enemyLeft && //Or if player's right edge is within the x-bounds of the enemy
            playerRight < enemyRight)) 
            && //And...
            ((playerBottom < enemyTop && //If the player's bottom edge is within the y-bounds of the enemy
            playerBottom > enemyBottom) ||
            (playerTop > enemyBottom && //Or the player's top edge is within the y-bounds of the enemy
            playerTop < enemyTop)))
        {
            touchingPlayer = true;
        }
        else
        {
            touchingPlayer = false;
        }

        /**
         * Deal damage to the player if there was a collision this frame
         */
        if (touchingPlayer && isHarmful)
        {
            player.GetComponent<Health>().Harm(15);
        }
    }
}
