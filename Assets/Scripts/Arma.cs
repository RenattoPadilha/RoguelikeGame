using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private bool fireInput;
    [SerializeField] private GameObject tiro;

    Vector3 mousePos;
    Vector2 dirArma;
    [SerializeField] private Transform arma;
    [SerializeField] private Transform bocaArma;

    float angle;
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CriaRaio();
    }

    private void FixedUpdate()
    {
        // Calcular a direção do mouse em relação ao personagem (no plano 2D)
        dirArma = new Vector2(mousePos.x - arma.position.x, mousePos.y - arma.position.y);

        // Calcular o ângulo da direção e converter para graus
        float angulo = Mathf.Atan2(dirArma.y, dirArma.x) * Mathf.Rad2Deg;

        // Rotacionar a arma para apontar na direção do mouse
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    private void CriaRaio()
    {
        if (arma.CompareTag("Arma1"))
        {
            fireInput = Input.GetMouseButtonDown(0);
        } 
        else 
        if (arma.CompareTag("Arma2"))
        {
            fireInput = Input.GetMouseButtonDown(1);
        }
        Quaternion rotation = arma.transform.rotation * Quaternion.Euler(0, 0, -90);
        if(fireInput)
        {

            Instantiate(tiro, new Vector3(bocaArma.transform.position.x, bocaArma.transform.position.y, bocaArma.transform.position.z), rotation);
        }
    }
}