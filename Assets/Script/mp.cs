using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp : MonoBehaviour
{
    public float move_speed;
    public Rigidbody2D rb;
    public float jump_force;
    public Animator animator;
    public AudioSource foot_step_audio;
    public AudioClip foot_step_clip;

    public AudioSource jump_step_audio;
    public AudioClip[] jump_step_clip;
    public AudioSource water_step_audio;
    public AudioClip[] water_step_clip;

    private bool isGrounded; // Tu pourras améliorer ça plus tard avec des collisions

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        is_walking(inputX);
        is_jumping(inputY);

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

    //détection de l'eau
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            jump_sound_random(water_step_clip, water_step_audio);
            transform.position = new Vector2(0, 1);
        }
    }

    //lecture du son quand marche
    private void is_walking(float input_x)
    {
        animator.SetFloat("Speed", Mathf.Abs(input_x));

        if (Mathf.Abs(input_x) > 0.1f)
        {
            //déplacement
            Vector2 movement = new Vector2(input_x * move_speed, rb.velocity.y);
            rb.velocity = movement;

            if (!foot_step_audio.isPlaying && isGrounded)
            {
                foot_step_audio.clip = foot_step_clip;
                foot_step_audio.Play();
            }
        }
    }

    //saut
    private void is_jumping(float input_y)
    {
        // animator.SetFloat("Jump", Mathf.Abs(input_y));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            isGrounded = false;

            //son du jump
            jump_sound_random(jump_step_clip, jump_step_audio);
        }
    }

    private void jump_sound_random(AudioClip[] audio_clip, AudioSource audio_source)
    {
        int index_random = Random.Range(0, audio_clip.Length);
        audio_source.clip = audio_clip[index_random];
        audio_source.Play();
    }

    private IEnumerator simple_timer_respawn(int time_second)
    {
        Debug.Log("Timer lancé");
        yield return new WaitForSeconds(time_second);
        Debug.Log("Timer terminé");
    }
}