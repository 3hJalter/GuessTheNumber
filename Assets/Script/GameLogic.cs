using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    public InputField userInput;
    public Text gameLabel;
    public Button userButton;
    public int randomNum;
    public int minValue = 0, maxValue = 100;
    private int check;
    private bool isGameWon = false;
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        //minValue = getMinValue(minValue);
        //maxValue = getMaxValue(maxValue);
        randomNum = GetRandomNumber(minValue, maxValue);  
        if (isGameWon == false)
        {    
            gameLabel.text = "Guess a number from " + minValue + " to " + (maxValue - 1);
        }
        else
        {
            isGameWon = false;
            gameLabel.text = "Your guess is correct after " + check + " steps\nNow guess a number from " + minValue + " to " + (maxValue - 1);
            check = 0;
        }
    }

    public void OnButtonClick()
    {
        // Code Block
        string userInputValue = userInput.text;
        if (userInput.text != "")
        {
            int answer = int.Parse(userInputValue);
            if (answer == randomNum)
            {
                check += 1;
                //userButton.interactable = false;
                isGameWon = true;
                ResetGame();
            }
            else if (answer > randomNum)
            {
                check += 1;
                gameLabel.text = "Your guess is higher than the answer!";
            }
            else
            {
                check += 1;
                gameLabel.text = "Your guess is lower than the answer!";
            }
        }
        else
        {
            gameLabel.text = "Please enter a number!";
        }
        

        // Debug.Log("Who clicked me?");
        // Debug.Log(userInput.text);
        // Debug.Log("Twice what you entered: " + answer);
        // Debug.Log("The random Number is " + randomNum);
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        Debug.Log("Max is: " + max);
        Debug.Log("Min is: " + min); 
        return random;
    }

    private int getMinValue(int minValue)
    {
        gameLabel.text = "Input the min value!";
        string userInputValue = userInput.text;
        if (userInputValue == "")
        {
            gameLabel.text = "Please enter a number!";
        }
        else
        {
            minValue = int.Parse(userInputValue);
        }
        return minValue;
    }

    private int getMaxValue(int maxValue)
    {
        gameLabel.text = "Input the max value!";
        string userInputValue = userInput.text;
        if (userInputValue == "")
        {
            gameLabel.text = "Please enter a number!";
        }
        else
        {
            maxValue = int.Parse(userInputValue);
            if (maxValue <= minValue)
            {
                gameLabel.text = "The max value must be higher than the min value";
            }
        }
        return maxValue;
    }
}
