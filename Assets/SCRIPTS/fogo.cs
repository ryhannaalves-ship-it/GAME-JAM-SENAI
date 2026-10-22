using UnityEngine;

public class fogo : MonoBehaviour
{
    void Start()
    {
        // Destrói a bala após 3 segundos para não poluir o jogo
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Não destrói ao encostar no próprio jogador
        if (collision.CompareTag("Player")) return;

        // Destrói a bala ao bater em qualquer outra coisa
        Destroy(gameObject);
    }
}

