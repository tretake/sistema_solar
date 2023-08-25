using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpo_seleste : MonoBehaviour
{

    public float Raio;
    public float Densidade;  //de 1000 -> 5000 é o normal
    public Vector3 Velocidade;
    public float Massa;
    public Vector3 Coordenada;

    public float escalaVelocidadeExecucao = 10000;
    public float escala_distancia = 1/1e10f;
    public float escala_raio = 1 / 1e10f;

    public void AplicarForca(Vector3 vetorForca)
    {
        Velocidade = Velocidade + (vetorForca / Massa) ;
    }

    public void AtualizarVisual()
    {
        transform.position = Coordenada*escala_distancia;
    }

    // Start is called before the first frame update
    void Start()
    {
        float Volume = (float)Math.Pow(Raio, 3) * 3.14f * (4.0f / 3.0f);
        Massa = Volume * Densidade;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Coordenada += Velocidade * escalaVelocidadeExecucao;
        AtualizarVisual();
    }
}
