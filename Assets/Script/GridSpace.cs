using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    
    private GameController gameController;
    
    public void Setspace()
    {
        if (gameController.playerMove == true)
        {
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }

    }

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;

    }

}
