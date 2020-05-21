using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private Vector2 move = Vector2.zero;

    private void Awake()
    {

    }


    private void Update()
    {
        move.x = move.y = 0;

        if (Input.GetKey("up"))
        {
            move.y = 1f;
        }
        else if (Input.GetKey("down"))
        {
            move.y = -1f;
        }

        if (Input.GetKey("right"))
        {
            move.x = 1f;
        }
        else if (Input.GetKey("left"))
        {
            move.x = -1f;
        }


    }

    public Vector2 GetMove()
    {
        return move;
    }


}//class
