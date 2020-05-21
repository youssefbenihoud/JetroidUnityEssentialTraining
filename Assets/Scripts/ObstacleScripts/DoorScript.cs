using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public const int IDLE = 0;
    public const int OPENING = 1;
    public const int OPEN = 2;
    public const int CLOSING = 3;
    public float closeDelay = .5f;

    private int state = IDLE;

    private Animator anim;
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnOpenStart()
    {
        state = OPENING;
    }

    void OnOpenEnd()
    {
        state = OPEN;
    }

    void OnCloseStart()
    {
        state = CLOSING;
    }

    void OnCloseEnd()
    {
        state = IDLE;
    }


    public void OpenDoor()
    {
        anim.SetInteger("AnimState", 1);
    }

    

    public void CloseDoor()
    {
        StartCoroutine(CloseNow());
      
    }

    private IEnumerator CloseNow()
    {
        yield return new WaitForSeconds(closeDelay);
        anim.SetInteger("AnimState", 2);
    }

    void DisableCollider2D()
    {
        boxCollider2D.enabled = false;
    }

    void EnableCollider2D()
    {
        boxCollider2D.enabled = true;
    }

}//class
