using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeCountLogic : MonoBehaviour
{

    public RawImage[] lives;
    public string GameOverSceneName;
    private int livesRemaining;
    private AudioSource hitSound;
    //public LifeCountLogic lifeCountLogic = new LifeCountLogic();
    // Start is called before the first frame update

    void Start()
    {
        livesRemaining = lives.Length - 1;
        hitSound = this.gameObject.GetComponent<AudioSource>();
    }

    public  void LooseLife()
    {
        //
        hitSound.Play();
        //Hide one life
        lives[livesRemaining].enabled = false;

        //Decrease number of lives
        livesRemaining--;

        //Check if dont have lives
        if (livesRemaining == -1)
        {
            SceneManager.LoadScene(GameOverSceneName);
        }
    }
}
