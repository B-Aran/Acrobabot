using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeCoinLogic : MonoBehaviour
{
    public AudioSource CoinEffect;
    public int points;
    //Can only collide 1 time per second
    private float counterTimer = 0;
    private float hitTimer = 1;
    private bool canCollide = false;
    private void Start()
    {
        CoinEffect = GetComponent<AudioSource>();
    }
    private void Update()
    {
        counterTimer += Time.deltaTime;
        if (counterTimer >= hitTimer)
        {
            canCollide = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCollide==true && collision.tag == "Player")
        {
            GameManager.GetInstance().score += points;
            Score.instance.updatePoints();
            CoinEffect.Play();
            canCollide = false;
            counterTimer = 0;
            Destroy(gameObject, 0.2f);
        }
    }
}
