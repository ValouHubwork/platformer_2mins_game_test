using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject go;
    private Vector3 position;

    void Update()
    {
        follow_player(go);
    }

    private void follow_player(GameObject gameObject)
    {
        if (gameObject.CompareTag("Player"))
        {
            position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, -10);
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 3);
        }
    }
}
