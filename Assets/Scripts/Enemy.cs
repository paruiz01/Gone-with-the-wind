using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public AudioClip deathClip;
    public GameOverScreen GameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(collision.gameObject);
            GameOver();
        }
    }

    public void GameOver()
    {
        
        GameOverScreen.Setup();
    }
}


// SceneManager.LoadScene(SceneManager.GetActiveScene().name);