using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasse die diePunkte steuert
/// </summary>
public class PointScript : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf das Script zum Speichern der Punkte
    /// </summary>
    public StatsScript statsScript;

    private void Start()
    {
        statsScript = FindAnyObjectByType<StatsScript>();
    }

    /// <summary>
    /// Ist der trigger ausgelöst
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfe, ob es der Spieler ist
        if(collision.tag == "Player")
        {
            // Punktestand erhöhen
            statsScript.ChangeScore(10);
            // Gameobject Point zerstören
            Destroy(gameObject);
        }

    }
}
