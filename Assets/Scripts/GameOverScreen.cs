using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    private Transform player;

    public void Setup ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive (true);
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;

    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
