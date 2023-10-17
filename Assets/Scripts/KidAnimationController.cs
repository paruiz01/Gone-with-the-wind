using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAnimationController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CheerUp();
        }
    }

    private void CheerUp()
    {
        anim.SetTrigger("happykid");
    }
}
