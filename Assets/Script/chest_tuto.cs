using UnityEngine;
using TMPro;
using System.Collections;

public class Chest_tuto : MonoBehaviour
{
    public TMP_Text messageText;
    public string message;
    private bool playerNear;
    public Animator animator;
    public Sprite openedSprite;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerNear && Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("Open");
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
        else
        {
            animator.SetTrigger("Close");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.text = message;
            playerNear = true;
            messageText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            messageText.enabled = false;
        }
    }
}
