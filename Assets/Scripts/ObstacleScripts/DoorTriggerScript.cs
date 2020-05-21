using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    [SerializeField]
    private DoorScript door;
    [SerializeField]
    private bool ignoreTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;

        if(target.gameObject.tag == "Player")
        {
            door.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;

        if (target.gameObject.tag == "Player")
        {
            door.CloseDoor();
        }
    }

    public void Toggle(bool val)
    {
        if (val)
            door.OpenDoor();
        else
            door.CloseDoor();
    }


    public DoorScript getDoor()
    {
        return door;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ignoreTrigger ? Color.red : Color.green;

        var bc2d = GetComponent<BoxCollider2D>();
        var bc2dPos = bc2d.transform.position;
        var newPos = new Vector2(bc2dPos.x + bc2d.offset.x, bc2dPos.y + bc2d.offset.y);

        Gizmos.DrawWireCube(newPos, new Vector2(bc2d.size.x, bc2d.size.y));
    }

}
