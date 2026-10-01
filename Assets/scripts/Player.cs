using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float forca = 10f;
    private bool isGrounded = false;

    [Header("Dash")]
    public float dashforce = 10f;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashDuration = 2f;

    public float moveHorizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       moveHorizontal = Input.GetAxis("Horizontal"); // vai reconhecer o movimento horizontal

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); // vai aplicar a velocidade horizontal 

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    void Dash()
    {
        float direction;

        if (moveHorizontal !=0)
        {
            direction = moveHorizontal;
        }
        else
        {
            direction = transform.localScale.x > 0 ? 1f : -1f;
        }


        isDashing = true;

        // Aplica a velocidade do Dash
        rb.linearVelocity = new Vector2(direction* dashforce,0f);


        //Depois da duração, volta ao movimento normal
        // Invoke(nameof(PararDash), dashDuration);

    }

    private void PararDash()
    {
        isDashing = false;

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; //vai reconhecer quando o jogador estiver encostando no chao
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; //vai reconhecer quando o jogador deixar de encostar no chao
        }
    }
}