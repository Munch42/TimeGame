﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorID;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
    
            foreach(Key key in pc.getKeys())
            {
                if(key.ID == doorID)
                {
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}