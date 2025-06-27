using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp : MonoBehaviour
{
    public float move_speed;
    public Rigidbody2D rb;
    public float jump_force;
    public Animator animator;

    private bool isGrounded = true; // Tu pourras améliorer ça plus tard avec des collisions

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //déplacement
        Vector2 movement = new Vector2(inputX * move_speed, rb.velocity.y);
        rb.velocity = movement;

        //saut 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            isGrounded = false;
        }

        //animation
        animator.SetFloat("Speed", Mathf.Abs(inputX)); // Met à jour le paramètre "Speed"

        if (inputX > 0)
            transform.localScale = new Vector3(1, 1, 1);  // vers la droite
        else if (inputX < 0)
            transform.localScale = new Vector3(-1, 1, 1); // vers la gauche

    }

    //détection sur le sol ou non
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Water"))
            transform.position = new Vector2(0, 1);
    }
}