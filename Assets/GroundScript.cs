using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

    public float jumpForce = 10f;
    int count = 1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (count == 0)
                    Destroy(gameObject);
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 144);
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                count--;
            }
        }

       
    }
}
