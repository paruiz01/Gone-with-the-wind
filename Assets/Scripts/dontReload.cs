using UnityEngine;

public class dontReload : MonoBehaviour
{
    void Awake()
    {
        // Avoid destruction of object when loading a new scene.
        DontDestroyOnLoad(transform.gameObject);

        // Find all objects with the tag "gameMusic".
        GameObject[] music = GameObject.FindGameObjectsWithTag("gameMusic");

        // Check if there's more than one music object.
        if (music.Length > 1)
        {
            // Destroy the second music object.
            Destroy(music[1]);
        }
    }
}
