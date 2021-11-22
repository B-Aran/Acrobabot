using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinLogic : MonoBehaviour
{
    public AudioSource CoinEffect;
    public int points;

    private void Start()
    {
        CoinEffect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.GetInstance().score += points;
            Score.instance.updatePoints();
            CoinEffect.Play();
            Destroy(gameObject, 0.2f);
        }
    }
}
