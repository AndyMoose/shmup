using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeX;

    private float newPos;
    private Vector2 startPos;

    void Start () {
        startPos = transform.position;
	}
	
	void Update () {
        newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPos + Vector2.left * newPos;
    }
}
