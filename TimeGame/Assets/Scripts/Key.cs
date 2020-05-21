using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string ID;

    private Color keyColour;
    private Color gemColour1;
    private Color gemColour2;

    private void Start()
    {
        int count = 0;

        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            if(count == 0)
            {
                keyColour = sr.color;
                count++;
            }
            else if (count == 1)
            {
                gemColour1 = sr.color;
                count++;
            } else if(count == 2)
            {
                gemColour2 = sr.color;
                count++;
            }
        }
    }

    public Color getKeyColour()
    {
        return keyColour;
    }

    public Color getGemColour1()
    {
        return gemColour1;
    }

    public Color getGemColour2()
    {
        return gemColour2;
    }
}
