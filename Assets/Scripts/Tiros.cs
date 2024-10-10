using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiros : MonoBehaviour
{
    [SerializeField] private int velocidadeBase = 15;

    private float tempo = 0.8f;

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(0, velocidadeBase * Time.deltaTime));
    }
}
