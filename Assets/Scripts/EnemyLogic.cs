using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    private LifeCountLogic lifeCountLogic;
    //Can only collide 1 time per second
    [HideInInspector]
    public float counterTimer=0;
    private float hitTimer = 1;
    [HideInInspector]
    public bool canCollide = false;
    //We make the walking path for our enemy
    public Vector3[] positions;
    [SerializeField]
    private float speed;
    private int index;
    //Death timer
    private float killTimer = 0;
    private float killTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        lifeCountLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeCountLogic>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Able to kill
        killTimer += Time.deltaTime;
        if (killTimer >= killTime)
        {
            gameObject.GetComponentInChildren<EnemyDead>().canDie = true;
            killTimer = 0;
        }
        
        //Collision Logic
        counterTimer += Time.deltaTime;
        if (counterTimer >= hitTimer)
        {
            canCollide = true;
        }

        //Movement logic
        this.transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);    
        if(transform.position == positions[index])
        {
            if(index == positions.Length - 1)
            {
                index = 0;
            }
            else{
                index++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCollide == true && collision.tag=="Player")
        {
            gameObject.GetComponentInChildren<EnemyDead>().canDie = false;
            canCollide = false;
            counterTimer = 0;
            lifeCountLogic.LooseLife();
        }
    }
}
