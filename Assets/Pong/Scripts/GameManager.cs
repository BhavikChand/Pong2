using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    
    //Modifiers
    public SpeedUpTrigger speedUpTrigger;
    public SpeedDownTrigger speedDownTrigger;

    //Count for left and right:
    int leftPlayerScore;
    int rightPlayerScore;
    Vector3 ballStartPos;
    public TextMeshProUGUI scoreText;


    const int scoreToWin = 11;

    //---------------------------------------------------------------------------
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    //---------------------------------------------------------------------------
    void SetCountText(int leftScore, int rightScore)
    {
        scoreText.text = "Score: " + leftScore.ToString() + "/" + rightScore.ToString();
        scoreText.color = new Color(Random.value, Random.value, Random.value);
    }
    
    //---------------------------------------------------------------------------
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball

        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");
            if (rightPlayerScore == scoreToWin)
                Debug.Log("Right player wins!");
            else
                ResetBall(-1f);
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");

            if (rightPlayerScore == scoreToWin)
                Debug.Log("Right player wins!");
            else
                ResetBall(1f);
        }
        
        SetCountText(leftPlayerScore, rightPlayerScore);
    }
    //---------------------------------------------------------------------------
    public void SpeedUpTrigger()
    {
        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity *= 1.20f;
        Debug.Log("Ball speed increased!");
    }

    public void SpeedDownTrigger(SpeedDownTrigger trigger)
    {
        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity *= 0.80f;
        Debug.Log("Ball speed decreased!");
    }


    //---------------------------------------------------------------------------
    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }
}
