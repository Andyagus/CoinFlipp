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
    public List<Turn> turnsList = new List<Turn>(128);
    private int scoreToAdd = 100;

    public struct Turn
    {
        public bool bet;
        public bool cameUp;
    }

    public void FlipCoin(bool guess)
    {
        bool randomSide = (Random.value > 0.5f);
        lostAlert.SetActive(false);
        wonAlert.SetActive(false);
        (randomSide == true ? headsCoin : tailsCoin).SetActive(true);
        (randomSide == false ? headsCoin : tailsCoin).SetActive(false);

        var correct = guess == randomSide;

        Turn turn = new Turn
        {
            bet = guess ? true : false,
            cameUp = randomSide ? true : false,

        };
        turnsList.Add(turn);

        if (correct)
        {
            wonAlert.SetActive(true);
            gameScore += scoreToAdd;
            scoreText.text = ($"{gameScore}");
        }
        else
        {
            lostAlert.SetActive(true);
            gameScore -= scoreToAdd;
            scoreText.text = ($"{gameScore}");
        }
    }

}

