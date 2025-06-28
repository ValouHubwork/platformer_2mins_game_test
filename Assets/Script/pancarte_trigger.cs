using UnityEngine;
using TMPro;
using System.Collections;


public class PancarteTrigger : MonoBehaviour
{
    public TMP_Text messageText;
    public string message;
    private bool player_near;

    private void Update()
    {
        if (player_near && Input.GetKey(KeyCode.E))
        {
            messageText.text = message;
            StartCoroutine(print_message());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_near = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_near = false;
        }
    }

    private IEnumerator print_message()
    {
        messageText.enabled = true;
        yield return new WaitForSeconds(3);
        messageText.enabled = false;
    }
}
