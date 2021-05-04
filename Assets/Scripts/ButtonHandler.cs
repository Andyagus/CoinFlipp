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
   

    public struct Turn{
        //make booleans
        public bool bet;
        public bool cameUp; 

    }


    void UpdateScore(int scoreToAdd)
    {
        gameScore += scoreToAdd;
        scoreText.text = ($"{gameScore}"); 
    }

    void FlipCoin(bool guess)
    {
        bool randomSide = (Random.value > 0.5f);
        lostAlert.SetActive(false);
        wonAlert.SetActive(false);
        (guess == true ? headsCoin : tailsCoin).SetActive(true);
        (guess == false ? headsCoin : tailsCoin).SetActive(false);

        var correct = guess == randomSide;

        Turn turn = new Turn
        {
            bet = guess ? true : false,
            cameUp = randomSide ? true : false,

        };

        turnsList.Add(turn);

        if (correct)
        {
            UpdateScore(scoreToAdd: 100);
            wonAlert.SetActive(true);
        }
        else
        {
            UpdateScore(scoreToAdd: -100);
            lostAlert.SetActive(true);

        }
    }

    public void headsClick()
    {
        FlipCoin(guess: true);
    }

    public void tailsClick()
    {
        FlipCoin(guess: false);
    }


}

