using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesLogic : MonoBehaviour
{
    private AudioSource CoinEffect;
    public int points;
    //Can only collide 1 time per second
    private float hitTimer = 0;
    private float hitTime = 1;
    private bool canCollide = false;
    private void Start()
    {
        CoinEffect = GetComponent<AudioSource>();
    }
    private void Update()
    {
        hitTimer += Time.deltaTime;
        if (hitTimer >= hitTime)
        {
            canCollide = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCollide == true && collision.tag == "Player")
        {
            GameManager.GetInstance().score += points;
            Score.instance.updatePoints();
            CoinEffect.Play();
            canCollide = false;
            hitTimer = 0;
            Destroy(gameObject, 0.2f);
        }
    }
}
