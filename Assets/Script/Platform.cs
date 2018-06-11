using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] Transform initialPoint;
    [SerializeField] Transform finalPoint;
    [SerializeField] int layer;
    [SerializeField] float speed;

    Rigidbody2D rb;
    Vector2 speedVector;
    bool reachFinal;
    float distance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(initialPoint.position);

        speedVector = new Vector2((initialPoint.position.x + finalPoint.position.x) / 2, (initialPoint.position.y + finalPoint.position.y) / 2);
        speedVector = new Vector2(speedVector.x / speedVector.magnitude * speed, speedVector.y / speedVector.magnitude * speed);

        distance = Vector2.Distance(initialPoint.position, finalPoint.position);
    }

    void FixedUpdate()
    {
        var ray = Physics2D.Raycast(initialPoint.position, finalPoint.position, layer);

        if (ray.distance >= distance)       reachFinal = true;
        else if (ray.distance <= 0)       reachFinal = false;

        if (reachFinal)     rb.velocity = -speedVector;
        else                rb.velocity = speedVector;

    }

}
