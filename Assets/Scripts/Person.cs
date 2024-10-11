using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private float horizontalInput; // PEGAR ENTRADAS DE COMANDO (W,S, SETAS CIMA E BAIXO)
    private float verticalInput;  // PEGAR ENTRADAS DE COMANDO (A, D, SETAS ESQUERDA E DIREITA)

    private Rigidbody2D rb;

    [SerializeField] private int velocidade = 10;

    private Animator animator;

    private int movendoHash = Animator.StringToHash("Andar");

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        animator.SetBool(movendoHash, horizontalInput != 0);

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (horizontalInput < 0) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position = transform.position + movement * velocidade * Time.deltaTime;
    }
}
