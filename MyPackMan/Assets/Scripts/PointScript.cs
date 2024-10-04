using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasse die diePunkte steuert
/// </summary>
public class PointScript : MonoBehaviour
{
    /// <summary>
    /// Ist der trigger ausgelöst
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfe, ob es der Spieler ist
        if(collision.tag == "Player")
        {
            // Gameobject Point zerstören
            Destroy(gameObject);
        }

    }
}
