using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [SerializeField] Text countText;
    [SerializeField] AudioSource collectAudio;
    private int countapple = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            collectAudio.Play();
            countapple++;
            countText.text = "Apples x " + countapple;
            Destroy(other.gameObject);
        }
    }
}
