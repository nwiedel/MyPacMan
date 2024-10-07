using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private Vector2 destination;

    /// <summary>
    /// Geschwindigkeit, mit der sich das Monster bewegen soll
    /// </summary>
    public float speed;

    /// <summary>
    /// Zeiger auf die Animator Komponente
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Die Richting in die sich das Monster als nächstes bewegen wird
    /// </summary>
    private Vector2 nextDirection;

    /// <summary>
    /// Die aktuelle Richtung in der sich das Monster bewegt
    /// </summary>
    private enum CurrentDirection { left, right, up, down};
    private CurrentDirection dir;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Erste Richtung festlegen
        dir = CurrentDirection.up;

        // Richtung in Form von Vector festlegen
        DetermineDirection();
    }

    private void FixedUpdate()
    {
        if ((Vector2)transform.position != destination)
        {
            // Zielpositione
            Vector2 pos = Vector2.MoveTowards(transform.position, destination, speed);

            // MovePosition ausführen
            myBody.MovePosition(pos);
        }
        
        // Animate
        Animate();

        // Überprüfe, ob die Bewegungsrichtung gültig ist
        if (IsValidDirection(nextDirection))
        {
            // keine Kollision => Monster in Richtung Zielrichtung bewegen
            SetDestination();
        }
        else
        {
            // Kollision mit dem Maze => neue Richtung festlegen
        }
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

    /// <summary>
    /// animiert das Monster je nach Richtung
    /// </summary>
    private void Animate()
    {
        // Richtung des Monsters auslesen
        Vector2 dir = destination - (Vector2)transform.position;
        // Werte für den Animator setzen (moveX, moveY)
        animator.SetFloat("moveX", dir.x);
        animator.SetFloat("moveY", dir.y);
    }

    /// <summary>
    /// überprüft, ob die Richtung valide ist oder das Monster 
    /// mit dem Maza kollidiert
    /// </summary>
    /// <param name="myDirection"></param>
    /// <returns>true oder false</returns>
    private bool IsValidDirection(Vector2 myDirection)
    {
        // Position des Monsters abspeichern
        Vector2 pos = transform.position;

        myDirection = myDirection +
            new Vector2(myDirection.x * 0.45f, myDirection.y * 0.45f);

        // Linecast
        RaycastHit2D hit = Physics2D.Linecast(pos + myDirection, pos);
        Debug.DrawLine(pos + myDirection, pos);

        // Überprüfe, ob es die Wand ist
        if (hit.collider.tag == "Maze")
        {
            Debug.Log("Wand erkannt!");
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// weist den Richtung des Enums einen Vector2 zu
    /// </summary>
    private void DetermineDirection()
    {
        switch (dir)
        {
            case CurrentDirection.left:
                nextDirection = Vector2.left;
                break;
            case CurrentDirection.right:
                nextDirection = Vector2.right;
                break;
            case CurrentDirection.up:
                nextDirection = Vector2.up;
                break;
            case CurrentDirection.down:
                nextDirection = Vector2.down;
                break;
        }
    }

    /// <summary>
    /// setzt das Ziel des Monsters 
    /// </summary>
    private void SetDestination()
    {
        destination = (Vector2)transform.position + nextDirection;
    }

    private void SetNewDirection()
    {
        // Neue Richtung festlegen
        // zufällige Richtung zuweisen
        // Sicherstellen, dass es nicht die bestehende Richtung ist
        // Variable zuweisen
        // Richtungsvektor zuweisen
    }
}
