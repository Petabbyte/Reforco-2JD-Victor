using UnityEngine;

public class Dash : MonoBehaviour
{
    public float forca = 10f;
    private Rigidbody2D rb;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }
}

