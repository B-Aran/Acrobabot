using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckpoint : MonoBehaviour
{
    public bool activated;
    public GameObject activatedSprite;
    private AudioSource checkpointSound;
    // Start is called before the first frame update
    private void Start()
    {
        activated = false;
        checkpointSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activated = true;
            activatedSprite.SetActive(true);
            checkpointSound.Play();
        }
    }
}
