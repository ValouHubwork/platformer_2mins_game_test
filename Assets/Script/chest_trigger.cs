using UnityEngine;
using TMPro;
using System.Collections;

public class ChestTrigger : MonoBehaviour
{
    public TMP_Text messageText;
    public string message;
    private bool playerNear;
    public Animator animator;
    public Sprite openedSprite;
    public int timer_second;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerNear && Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("Open");
            messageText.text = message;
            StartCoroutine(print_message(timer_second));
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
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
    
    private IEnumerator print_message(int timer)
    {
        messageText.enabled = true;
        yield return new WaitForSeconds(timer);
        messageText.enabled = false;
    }
}
