using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private bool fireInput;
    [SerializeField] private GameObject tiro;

    Vector2 mousePos;
    Vector2 dirArma;

    float angle;

    [SerializeField] float tempoEntreTiros;
    [SerializeField] Transform bocaDaArma;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        fireInput = Input.GetMouseButtonDown(0);

        criaTiro();

        dirArma = mousePos - new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Atan2(dirArma.y, dirArma.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void criaTiro()
    {
        if(fireInput)
        {
            Instantiate(tiro, new Vector3(bocaDaArma.transform.position.x, bocaDaArma.transform.position.y, bocaDaArma.transform.position.z), bocaDaArma.transform.rotation);
        }
    }
}