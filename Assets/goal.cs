using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    public TMPro.TextMeshProUGUI scoreText;

    public float waitSecondsAfterGoal = 3;
    private float pauseTimer = 0;
    private bool goalEnabled = true;

    public Collider2D ball;

    private string buildScore ()
    {
        return playerOneScore.ToString() + " - " + playerTwoScore.ToString();
    }

    // Start is called before the first frame update
    
    void Start()
    {
        scoreText = GameObject.Find("score-text").GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = buildScore();

        ball = GameObject.Find("Ball").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;

            if ((int)pauseTimer < (int) (pauseTimer + Time.deltaTime))
            {
                Debug.Log("Restarting in: " + ((int)pauseTimer+1).ToString());
            }
            
            if (pauseTimer <= 0) {
                goalEnabled = true;
                pauseTimer = 0;

                ball.transform.position = new Vector2((float)0.0, (float)1.5);
                ball.attachedRigidbody.velocity = new Vector2((float)0.0, (float)0.0);
                ball.attachedRigidbody.angularVelocity = (float)0.0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The trigger " + this.gameObject.name + " has been triggered");

        if (goalEnabled && other.gameObject.name == "Ball")
        {
            if (this.gameObject.name == "goalpost-background-left")
            {
                playerTwoScore += 1;
            }
            if (this.gameObject.name == "goalpost-background-right")
            {
                playerOneScore += 1;
            }

            Debug.Log(playerOneScore);
            Debug.Log(playerTwoScore);

            scoreText.text = buildScore();
            pauseTimer = waitSecondsAfterGoal;
            goalEnabled = false;
        }
    }

    
}
