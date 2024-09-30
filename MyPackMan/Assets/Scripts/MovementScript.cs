using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private Vector2 nextDirection;

    public float speed = 0.2f;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tasteninput erkennen
        if(Input.GetAxis("Horizontal") > 0)
        {
            //nach rechts laufen
            Debug.Log("nach rechts laufen");
            nextDirection = Vector2.right;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            // nach links laufen
            Debug.Log("nach links laufen");
            nextDirection = Vector2.left;
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            // nach oben laufen
            Debug.Log("nach oben laufen");
            nextDirection = Vector2.up;
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            // nach unten laufen
            Debug.Log("nach unten laufen");
            nextDirection = Vector2.down;
        }

        // Richtung berechnen
        direction = (Vector2)transform.position + nextDirection;
        Vector2 myPosition = Vector2.MoveTowards(transform.position, direction, speed);
        // Anweisung, das sich Pacman bewegen soll
        rb2d.MovePosition(myPosition);
    }
}
