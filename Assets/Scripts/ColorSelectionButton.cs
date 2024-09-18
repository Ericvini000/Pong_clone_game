using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;
    public bool isColorPlayer;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if(isColorPlayer) 
            SaveController.Instance.playerColor = paddleReference.color;
        else 
            SaveController.Instance.enemyColor = paddleReference.color;
    }
}
