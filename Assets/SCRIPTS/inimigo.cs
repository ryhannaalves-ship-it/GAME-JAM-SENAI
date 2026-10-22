using UnityEngine;
public class inimigo : MonoBehaviour
{
    [Header("Pontos de Patrulha")]
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 2f;

    [Header("Ataque")]
    public Transform jogador;
    public float distanciaAtaque = 1.2f;
    public float tempoEntreAtaques = 1.5f;
    public int dano = 10;

    private Transform alvoAtual;
    private float proximoAtaque;

    void Start()
    {
        alvoAtual = pontoB; // Começa indo em direção ao Ponto B
    }

    void Update()
    {
        if (jogador == null) return;

        float distanciaDoJogador = Vector2.Distance(transform.position, jogador.position);

        // Se o jogador estiver perto, ataca. Se não, patrulha.
        if (distanciaDoJogador <= distanciaAtaque)
        {
            Atacar();
        }
        else
        {
            Patrulhar();
        }
    }

    void Patrulhar()
    {
        // Move em direção ao ponto atual
        transform.position = Vector2.MoveTowards(transform.position, alvoAtual.position, velocidade * Time.deltaTime);

        // Troca de ponto ao chegar perto
        if (Vector2.Distance(transform.position, alvoAtual.position) < 0.1f)
        {
            alvoAtual = (alvoAtual == pontoA) ? pontoB : pontoA;
            Virar();
        }
    }

    void Atacar()
    {
        if (Time.time >= proximoAtaque)
        {
            proximoAtaque = Time.time + tempoEntreAtaques;
            Debug.Log("Inimigo atacou! Dano: " + dano);

            // Se o seu jogador tiver um script de vida, chame aqui:
            // jogador.GetComponent<VidaJogador>()?.ReceberDano(dano);
        }
    }

    void Virar()
    {
        // Inverte o lado do sprite (flip horizontal)
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
