using UnityEngine;

public class ataque : MonoBehaviour
{
    public GameObject prefabProjetil;
    public Transform pontoDeDisparo;
    public float velocidadeProjetil = 10f;
    public vidainimigo Binimigo;

    void Update()
    {
        // Atira com a tecla Espaço ou Botão Esquerdo do Mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        // Cria o projétil no ponto de disparo
        GameObject projetil = Instantiate(prefabProjetil, pontoDeDisparo.position, Quaternion.identity);

        // Define a direção com base para onde o personagem está olhando
        float direcao = transform.localScale.x > 0 ? 1f : -1f;

        // Inverte o sprite da bala se estiver atirando para a esquerda
        Vector3 escala = projetil.transform.localScale;
        escala.x *= direcao;
        projetil.transform.localScale = escala;

        // Faz a bala andar para a esquerda ou direita
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(velocidadeProjetil * direcao, 0);

        Binimigo.TakeDamage(1f);


    }
}
