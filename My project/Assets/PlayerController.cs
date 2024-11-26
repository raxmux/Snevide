using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private GameObject textObj;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * PlayerStats.speed;
        float moveY = Input.GetAxis("Vertical") * PlayerStats.speed;

        Vector2 movement = new Vector2(moveX, moveY);
        rb2d.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Hit trigger object");
            textObj.SetActive(true);
        }
    }
}
