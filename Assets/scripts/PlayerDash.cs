using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float forca = 10f;
    private Rigidbody2D rb;
    private float direcao;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("teste");
            Dash();
        }
    }

    void Dash()
    {
        if (direcao == 0)
        {
            float direcao = transform.localScale.x > 0 ? 1 : -1;
        }
        rb.linearVelocity = new Vector2(direcao * forca, rb.linearVelocity.y);
    }
}
