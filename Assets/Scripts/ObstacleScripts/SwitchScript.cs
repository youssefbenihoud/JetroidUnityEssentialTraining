using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField]
    private DoorTriggerScript[] doorTriggers;
    [SerializeField]
    private bool sticky;
    private bool down;

    private Animator anim;
    //[SerializeField]
    //private DoorScript door;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        down = true;
        foreach(DoorTriggerScript trigger in doorTriggers)
        {
            if(trigger != null)
            {
                trigger.Toggle(true);
            }
        }


        anim.SetInteger("AnimState", 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sticky && down)
            return;

        down = false;
        foreach (DoorTriggerScript trigger in doorTriggers)
        {
            if (trigger != null)
            {
                trigger.Toggle(false);
            }
        }

        anim.SetInteger("AnimState", 2);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = sticky ? Color.red : Color.green;
        foreach(DoorTriggerScript trigger in doorTriggers)
        {
            if(trigger != null)
            {
                Gizmos.DrawLine(transform.position, trigger.getDoor().transform.position);
            }
        }
    }
}
