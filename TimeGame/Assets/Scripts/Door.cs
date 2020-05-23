using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorID;
    public bool leftExit;
    public bool rightExit;

    Animator doorAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

            int count = 0;

            foreach(Key key in pc.getKeys())
            {
                if(key.ID == doorID)
                {
                    doorAnim = gameObject.GetComponentInParent<Animator>();
                    doorAnim.SetTrigger("hasKey");  
                    List<Key> keys = pc.getKeys();
                    keys.RemoveAt(count);
                    pc.setKeys(keys);
                    //Destroy(this.gameObject);
                    break;
                }

                count++;
            }
        }
    }
}
