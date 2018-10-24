using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public GameManager gamemanager;
    public AudioClip hit;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        gamemanager.AddScore();
        source.PlayOneShot(hit);
    }
}
