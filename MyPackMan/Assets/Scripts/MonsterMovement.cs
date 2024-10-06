using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    /// <summary>
    /// Teiger auf die RigidBody Komponente
    /// </summary>
    private Rigidbody2D myBody;

    /// <summary>
    /// Richtung, in die das Monster sich bewegen soll
    /// </summary>
    public Vector2 destination;

    /// <summary>
    /// Geschwindigkeit, mit der sich das Monster bewegen soll
    /// </summary>
    public float speed;

    /// <summary>
    /// Zeiger auf die Animator Komponente
    /// </summary>
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Zielpositione
        Vector2 pos = Vector2.MoveTowards(transform.position, destination, speed);
        
        // MovePosition ausführen
        myBody.MovePosition(pos);

        // Animate
        Animate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // überprüfe, ob es sich um Pacman handelt
        if(collision.tag == "Player")
        {
            // Destroy(collision.gameObject);
            // Scenen Neustart
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Animate()
    {
        // Richtung des Monsters auslesen
        Vector2 dir = destination - (Vector2)transform.position;
        // Werte für den Animator setzen (moveX, moveY)
        animator.SetFloat("moveX", dir.x);
        animator.SetFloat("moveY", dir.y);
    }
}
