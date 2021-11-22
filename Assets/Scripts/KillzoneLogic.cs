using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class KillzoneLogic : MonoBehaviour
    {
        private LifeCountLogic lifeCountLogic;
        private ActivateCheckpoint activateCheckpoint;
        private GameObject player;
        public Transform InitialSpawn;
        public Transform Checkpoint;


        private void Awake()
        {
            lifeCountLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeCountLogic>();
            player = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                lifeCountLogic.LooseLife();
                if (FindObjectOfType<ActivateCheckpoint>().activated)
                {
                    player.transform.position = Checkpoint.position;
                }
                else
                {
                    player.transform.position = InitialSpawn.position;
                }
                
            }
        }
    }
}
