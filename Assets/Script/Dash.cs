using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    [SerializeField] float speed, delay, delayPress;
    [SerializeField] GameObject particle;
    [HideInInspector] public bool startDelay;
    Rigidbody2D rb;
    int rightPress, leftPress;
    float timePassed, timePassedPress;
    bool startTimer;

	// Use this for initialization
	void Start () {
        rightPress = 0;
        leftPress = 0;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("left"))
        {
            leftPress++;
            rightPress = 0;
            startTimer = true;
        }
        else if (Input.GetButtonDown("right"))
        {
            rightPress++;
            leftPress = 0;
            startTimer = true;
        }

        if (startTimer)
        {
            timePassedPress += Time.deltaTime;
            if (timePassedPress >= delayPress)
            {
                startTimer = false;
                leftPress = 0;
                rightPress = 0;
                timePassedPress = 0;
            }
        }

        if (leftPress >= 2 || rightPress >= 2)
        {
            startDelay = true;
            Instantiate(particle, transform, false);
        }
	}

    void FixedUpdate()
    {
        if (startDelay)
        {
            timePassed += Time.fixedDeltaTime;

            if (timePassed <= delay)
            {
                if (rightPress >= 2)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    rightPress = 0;
                }
                else if (leftPress >= 2)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    leftPress = 0;
                }
            }
            else
            {
                timePassed = 0;
                startDelay = false;
                rightPress = 0;
                leftPress = 0;
            }
        }
    }
}
