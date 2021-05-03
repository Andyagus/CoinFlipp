using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject headsCoin;
    [SerializeField] GameObject tailsCoin;
    [SerializeField] GameObject lostAlert;
    [SerializeField] GameObject wonAlert;
    [SerializeField] float gameScore;
    [SerializeField] TextMeshProUGUI scoreText;
    //unable to make field readonly since it's being accesed from the pause controller - discuss with eugene a different approach 
    public List<Turn> turnsList = new List<Turn>();
   

    public class Turn{

        public string bet;
        public string cameUp; 
        

    }


    void UpdateScore(int scoreToAdd)
    {
        gameScore += scoreToAdd;
        scoreText.text = ""+gameScore;
    }

    void FlipCoin(string guess)
    {
        bool randomSide = (Random.value > 0.5f);
        lostAlert.SetActive(false);
        wonAlert.SetActive(false);

        if (guess== "tails")
        {
            if(randomSide == false)
            {
                UpdateScore(scoreToAdd: 100);
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
    }

    public void headClick()
    {
        FlipCoin(guess: "heads");
    }



}
