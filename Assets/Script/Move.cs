﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Rigidbody2D rb;
    int travellingDirection;
    [SerializeField] float speed;
    Dash dash;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        dash = GetComponent<Dash>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            travellingDirection = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            travellingDirection = -1;
        }
        else
        {
            travellingDirection = 0;
        }
	}

    void FixedUpdate()
    {
        if (!dash.startDelay)
        {
            rb.velocity = new Vector2(travellingDirection * speed, rb.velocity.y);
        }
    }
}
