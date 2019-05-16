using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float upForce = 200f;

    private bool isDead;
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Flap");
                rigidBody2D.velocity = Vector2.zero;
                rigidBody2D.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        rigidBody2D.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Die");
        GameManager.Instance.BirdDied();
    }
}
