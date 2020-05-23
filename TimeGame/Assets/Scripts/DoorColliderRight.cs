using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderRight : MonoBehaviour
{
    private bool exitRight;
    private Animator anim;
    private bool called = false;

    // Start is called before the first frame update
    void Start()
    {
        exitRight = GetComponentInParent<Door>().rightExit;
        anim = gameObject.transform.parent.parent.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && exitRight)
        {
            if (!called)
            {
                anim.SetTrigger("isClosing");
                called = true;
            }

            if(called && GetComponentInParent<TimeBody>().getRewindStatus())
            {
                anim.SetTrigger("isClosing");
                called = false;
            }
        }
    }

    public bool getCalledStatus()
    {
        return called;
    }
}
