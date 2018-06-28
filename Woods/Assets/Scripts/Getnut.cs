using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Getnut : MonoBehaviour {
    public Text ScoreText;
    private int Score;
    
    // Use this for initialization
	void Start () {
        Score = 1;
        SetScore();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           gameObject.SetActive(false);
            Score -= 1;
        }
            SetScore();
    }

    void SetScore()
    {
       ScoreText.text = "木の実残り"+Score.ToString();
        if (Score == 0)
        {

        }
    }
}
