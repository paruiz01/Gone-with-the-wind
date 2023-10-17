using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player movement variables
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Audio-related variables
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip happySound;
    private AudioSource[] audioSources;

    // Kid-related variables
    public GameObject kid;
    private int count;

    //Screen variables
    public GameObject SceneStart;
    public GameOverScreen GameOverScreen;
    public WinScreen WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        SceneStart.SetActive(true);
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            PlaySound(0,jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetButtonUp("Jump"))
        {
            BalloonFall();
        }


        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void BalloonFall()
    {
        rb.drag = 2;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            if (count == 1)
            {
                kid.gameObject.SetActive(false);
            }
        }

        if(other.gameObject.CompareTag("winkid"))
        {
            AudioSource winkidAudioSource = other.gameObject.GetComponent<AudioSource>();

            if (winkidAudioSource != null)
            {
                winkidAudioSource.Stop();
            }

            PlaySound(1, happySound);
            StopPlayer();
            WinScreen.Setup();
        }
    }

    void PlaySound(int sourceIndex, AudioClip clip)
    {
        if (sourceIndex < audioSources.Length && clip != null)
        {
            audioSources[sourceIndex].PlayOneShot(clip);
        }
    }

    public void Win()
    {
        WinScreen.Setup();
    }

    public void StopPlayer()
    {
        rb.isKinematic = false;
    }    
}
