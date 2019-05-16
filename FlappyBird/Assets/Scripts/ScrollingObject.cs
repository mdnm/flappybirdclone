using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidBody2D.velocity = new Vector2 (GameManager.Instance.scrollSpeed, 0);
    }

    private void Update()
    {
        if(GameManager.Instance.GameOver == true)
        {
            rigidBody2D.velocity = Vector2.zero;
        }
    }
}
