using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 maxValues = new Vector2(3f, 5f);
    private bool standing;
    private float jetSpeed = 15f;
    private float airSpeedMultiplayer = .3f;

    private Rigidbody2D body2D;
    private SpriteRenderer sr;
    private Animator anim;
    private PlayerControllerScript playerController;
    // Start is called before the first frame update
    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerControllerScript>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }//update


    private void Move()
    {
        var absVelX = Mathf.Abs(body2D.velocity.x);
        var absVelY = Mathf.Abs(body2D.velocity.y);
        standing = (absVelY < 0.2);

        float forceX = 0f;
        float forceY = 0f;

        if (playerController.GetMove().x != 0)
        {
            if (absVelX < maxValues.x)
            {
                forceX = (standing ? speed : speed * airSpeedMultiplayer) * playerController.GetMove().x;
                sr.flipX = playerController.GetMove().x < 1;
                anim.SetInteger("AnimState", 1);
            }
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        }

        if (playerController.GetMove().y != 0)
        {
            if (absVelY < maxValues.y)
            {
                forceY = jetSpeed * playerController.GetMove().y;
                anim.SetInteger("AnimState", 2);
            }
        }
        else if ((absVelY > 0 && !standing))
        {
            anim.SetInteger("AnimState", 3);
        }


        Debug.Log("ForceX = " + forceX);
        body2D.AddForce(new Vector2(forceX, forceY));
    }
}
