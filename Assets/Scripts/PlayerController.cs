using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private float xMin, xMax, yMin, yMax;
    private new Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        xMin = -12f;
        xMax = 12f;
        yMin = -6f;
        yMax = 6f;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector2(
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            Mathf.Clamp(rigidbody.position.y, yMin, yMax)
            );
    }
}