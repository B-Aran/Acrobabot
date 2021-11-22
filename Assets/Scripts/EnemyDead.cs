using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    //The enemy we want to kill
    private GameObject enemy;
    private AudioSource enemyDeath;

    //If we hit the collider to avoid double scores or double audiosource plays
    private bool hit;
    
    [HideInInspector]
    public bool canDie;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
        enemyDeath = gameObject.transform.parent.GetComponent<AudioSource>();
        canDie = true;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canDie == true && collision.tag == "Player")
        {
            if (!hit)
            {
                hit = true;

                //Adding points to score
                GameManager.GetInstance().score += points;
                Score.instance.updatePoints();

                //Killing the enemy
                enemyDeath.Play();
                enemy.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(enemy, 0.2f);
     
            }
        }
    }
}
