using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player : MonoBehaviour
{

    public Rigidbody2D rb;

    public float points;

    public TMP_Text pointsTxt;

    public float jumpSpeed;
    void Update()
    {
        Jump();

        pointsTxt.text = $"Points: {points}";

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 5);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // jumps into death scene
        SceneManager.LoadScene(1);

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            points += 1;

        }
    }
}
