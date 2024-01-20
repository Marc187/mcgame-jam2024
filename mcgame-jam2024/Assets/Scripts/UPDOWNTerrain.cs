using UnityEngine;

public class UPDOWNTerrain : MonoBehaviour
{
    public float amplitude = 0.5f; // L'amplitude du mouvement de haut en bas
    public float frequency = 1f; // La fréquence du mouvement de haut en bas

    // Position initiale de l'objet
    private Vector3 startPos;

    void Start()
    {
        // Enregistrement de la position de départ
        startPos = transform.position;
    }

    void Update()
    {
        // Flottement
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}

