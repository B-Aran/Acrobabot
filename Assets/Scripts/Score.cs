using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scorePoints;
    public static Score instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scorePoints.text = GameManager.GetInstance().score.ToString();
    }

   public void updatePoints()
    {
        scorePoints.text = GameManager.GetInstance().score.ToString();
    }
}
