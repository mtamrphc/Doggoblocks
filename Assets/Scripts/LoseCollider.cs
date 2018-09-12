using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    //cached refences
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioClip clip = myAudioSource.clip;
        myAudioSource.PlayOneShot(clip);
        SceneManager.LoadScene("Game Over");
    }
}
