using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioSource deathAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("trap"))
        {
            animator.SetTrigger("Death");
            GetComponent<Movement>().enabled = false;
            deathAudio.Play();
            Invoke("RestartLevel", 1.5f); 
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
