using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour
{
    /// <summary>
    /// Zentrale Stelle zum Speichern der Punkte
    /// </summary>
    public int score;

    /// <summary>
    /// Zeiger auf das Textfeld zum Darstellen der Punkte
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// wird abgespielt, wenn man Pacman einen Punkt frisst
    /// </summary>
    public AudioSource pointsAudioSource;

    // Methode um den Punktestand z ändern
    public void ChangeScore(int newPoints)
    {
        // Punktestand erhöhen ( addieren)
        score += newPoints;
        // Textfeld aktualisieren
        scoreText.text = score.ToString();
        // Wird die Audioqueele abgespielt?
        if(!pointsAudioSource.isPlaying)
        {
            // Audio abspielen
            pointsAudioSource.Play();
        }
        
    }
}
