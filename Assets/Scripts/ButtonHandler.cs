using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject headsCoin;
    public GameObject tailsCoin;
    public GameObject lostAlert;
    public GameObject wonAlert;
    public float gameScore;
    public TextMeshProUGUI scoreText;
    public List<Turn> turnsList;
    //public Dictionary<int, string> userScores; 
    //public Dictionary<int, string> turns = new Dictionary<int, string>();

    public class Turn{

        public string bet;
        public string cameUp;
        

    }

    void Start()
    {
        turnsList = new List<Turn>();

        //Turn turn1 = new Turn();
        //turn1.bet = true;
        //turn1.cameUp = false;

        //turn1.printTurns;
        //Debug.Log("hi" + turn1.bet);
    }


    private void UpdateScore(int scoreToAdd)
    {
        gameScore += scoreToAdd;
        scoreText.text = ""+gameScore;
    }

    private void FlipCoin(string guess)
    {
        bool randomSide = (Random.value > 0.5f);
        lostAlert.SetActive(false);
        wonAlert.SetActive(false);

        if (guess== "tails")
        {
            if(randomSide == false)
            {
                UpdateScore(scoreToAdd: 100);
                //Debug.Log("You clicked: Tails -> RIGHT! + 100");
                tailsCoin.SetActive(true);
                headsCoin.SetActive(false);
                wonAlert.SetActive(true);
                Debug.Log("You won! Bet: Tails/ Came up Tails");
                Turn turn1 = new Turn();
                turn1.bet = "tails";
                turn1.cameUp = "tails";
                turnsList.Add(turn1);
          
            }
            else
            {
                UpdateScore(scoreToAdd: -100);
                tailsCoin.SetActive(false);
                headsCoin.SetActive(true);
                lostAlert.SetActive(true);
                //Debug.Log("Heads you were WRONG! -100");
                Debug.Log("You Lost! Bet: Tails/ Came up Heads");
                Turn turn1 = new Turn();
                turn1.bet = "tails";
                turn1.cameUp = "heads";
                turnsList.Add(turn1);


            }
        }

        if(guess == "heads")
        {
            Debug.Log("heads");
            if(randomSide == true)
            {
                UpdateScore(scoreToAdd: 100);
                Debug.Log("You clicked: Heads - RIGHT! + 100");
                wonAlert.SetActive(true);
                headsCoin.SetActive(true);
                tailsCoin.SetActive(false);
                //turns.Add(1, "Heads");
                Turn turn1 = new Turn();
                turn1.bet = "heads";
                turn1.cameUp = "heads";
                turnsList.Add(turn1);


            }
            else
            {
                UpdateScore(scoreToAdd: -100);
                Debug.Log("You clicked Heads: WRONG! -100");
                lostAlert.SetActive(true);
                tailsCoin.SetActive(true);
                headsCoin.SetActive(false);
                Turn turn1 = new Turn();
                turn1.bet = "heads";
                turn1.cameUp = "tails";
                turnsList.Add(turn1);
            }
        }       

    }

   
    public void tailsClick()
    {
        FlipCoin(guess: "tails");

        //Debug.Log("You Clicked Tails");
    }

    public void headClick()
    {
        FlipCoin(guess: "heads");
    }



    void Update()
    {
                
    }
}
