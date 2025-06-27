using UnityEngine;
using TMPro;

public class ChestTrigger : MonoBehaviour
{
    public TMP_Text messageText;
    public string message = "Appuie sur E pour ouvrir le coffre !";
    private bool playerNear = false;
    public Animator animator;
    public Sprite openedSprite;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Open");
            messageText.enabled = false; // cache le message une fois ouvert
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
            messageText.enabled = true;
            playerNear = true;
            GetComponent<SpriteRenderer> ().sprite = openedSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.enabled = false;
            playerNear = false;
        }
    }
}
