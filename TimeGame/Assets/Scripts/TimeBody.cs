using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    // Good Idea to make this private
    private bool isRewinding;

    public float maxSeconds = 5f;
    public bool resetVelocity = true;
    public bool kinematic = false;

    List<PointInTime> pointsInTime;

    Rigidbody2D rb;

    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        } else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        } else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if(pointsInTime.Count > Mathf.Round(maxSeconds / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    // Make both of these methods public to access in other scripts ie rewind gun.
    void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    void StopRewind()
    {
        isRewinding = false;

        if (!kinematic)
        {
            rb.isKinematic = false;
        }

        if (resetVelocity)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
