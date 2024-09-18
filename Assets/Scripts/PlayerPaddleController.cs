using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 5f;
    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start() {
        if(isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.playerColor;

        }else {
            spriteRenderer.color = SaveController.Instance.enemyColor;

        }
    }
    void Update()
    {
        // Captura da entrada vertical (seta para cima e seta para baixo, W e S)
        float moveInput = Input.GetAxis(movementAxisName);

        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limita a posição vertical da raquete para que ela não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.3f, 4.3f);

        // Atualiza a posição da raquete
        transform.position = newPosition;  
    }
}
