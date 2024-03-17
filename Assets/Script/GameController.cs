using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public TMP_Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColer
{
    public Color panelColer;
    public Color textColor;

}
public class GameController : MonoBehaviour
{
 
    public TMP_Text[]buttonList;
    private string playerSide;
    private string computerSide;
    public bool playerMove;
    public float delay;
    private int value; 

    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    private int moveCount;

    public GameObject restartButton;

    [SerializeField] private Player playerX;
    [SerializeField] private Player playerO;
    [SerializeField] private PlayerColer activePlayerColor;
    [SerializeField] private PlayerColer inactivePlayerColor;
    [SerializeField] private GameObject startInfo;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferneceOnButtons();    
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;
        
    }

    public void Update()
    {
        if (playerMove == false)
        {
            delay += delay * Time.deltaTime;
            if (delay >= 2) 
            {
                value = Random.Range(0, 8);
                if (buttonList[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonList[value].text = GetComputerSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    private void SetGameControllerReferneceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            computerSide = "O";
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            computerSide = "X";
            SetPlayerColor(playerO, playerX);
        }
        StartGame();
    }

    public void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButton(false);

        startInfo.SetActive(false);

    }

    public string GetPlayerSide()
    {
        return playerSide;
    }
    public string GetComputerSide()
    {
        return computerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else 
        { 
            ChangeSides();
            delay = 2;
        }
        
    }

    private void SetPlayerColor(Player newPlayer , Player oldPlayer) 
    {
        newPlayer.panel.color = activePlayerColor.panelColer;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = activePlayerColor.panelColer;
        oldPlayer.text.color = activePlayerColor.textColor;

    }
    private void GameOver(string winnerPlayer)
    {
        SetBoardInteractable(false);

        if (winnerPlayer == "draw")
        {
            SetGameOverText("Draw");
            SetPlayerColorInactive();

        }
        else
        {
            SetGameOverText(winnerPlayer + " Win");
        }
        restartButton.SetActive(true);

    }
    private void ChangeSides()
    {
        //playerSide = (playerSide == "X") ? "O" : "X";
        playerMove = (playerMove == true) ? false : true;

        //if (playerSide == "X")
        if (playerMove == true)
        {
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            SetPlayerColor(playerO, playerX);
        }
    }

    public void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButton(true);
        SetPlayerColorInactive();
        startInfo.SetActive(true);
        playerMove = true;
        delay = 2;


        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }

    }

    public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    public void SetPlayerButton(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    public void SetPlayerColorInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColer;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColer;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
