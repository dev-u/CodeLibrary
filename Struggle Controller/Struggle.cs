public class EnemyController : MonoBehaviour
{
    public Collider2D playerCol; //player collider
    public PlayerController pc;  //player controller
    public Rigidbody2D playerRB; //player rigidbody

    //variáveis do evento
    private int struggleEnd; //contador de cliques para sair do evento
    private bool isStruggling = false; //verificação do evento
    public RigidbodyConstraints2D startConst; //variável pra armazenar as constraints iniciais

    private void Awake() {
        startConst = playerRB.constraints; //salvando as constraints iniciais
    }
    private void Update()
    {
        //Tecla para cancelar o evento
        if(Input.GetKeyDown(KeyCode.K))
            struggleEnd++; //iteração do evento
        //Verificação se o evento está ativo
        if (isStruggling)
        {
            pc.TakeDamage(0.01f); //chama a função de dano ao player
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //detecta início da colisão
    {
        if (collision.collider == playerCol) //verifica se o collider é o do player
        {
            isStruggling = true; //ativa o bool do evento
            struggleEnd = 0; //zera o contador do evento
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll; //bloqueia o movimento do player

            Debug.Log("Struggle");
        }
            
    }

    private void OnCollisionStay2D(Collision2D collision) //detecta se a colisão está ativa
    {
        if(struggleEnd >= 5) //verifica a condição de parada do evento
        {
            isStruggling = false; //interrompe o evento
            OnCollisionExit2D(collision); //chama o encerramento do evento
        }
            
    }
    private void OnCollisionExit2D(Collision2D collision) //detecta saída da colisão
    {
        if (collision.collider == playerCol)
        {
            isStruggling = false; //desativa o bool do evento
            playerRB.constraints = startConst; //retorna as constraints iniciais
            Debug.Log("Free");
        }
            
    }

}
