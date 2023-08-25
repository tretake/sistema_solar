using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class Forças : MonoBehaviour
{


    public float escalaVelocidadeExecucao = 100.0f;


    void ForcaGravidade(ref Corpo_seleste C1, ref Corpo_seleste C2)
    {

        Vector3 distancia = (C1.Coordenada - C2.Coordenada);
        float G = 6.6743e-11f;
        float forca = G * (C1.Massa * C2.Massa) / (distancia.magnitude * distancia.magnitude);

        Vector3 vetorForca = distancia.normalized * (forca);


        C1.Velocidade += (-vetorForca / C1.Massa)*escalaVelocidadeExecucao;
        C2.Velocidade += (vetorForca / C2.Massa)*escalaVelocidadeExecucao;
    }

    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {

        Transform childTransform1;
        Corpo_seleste childScript1;

        Transform childTransform2;
        Corpo_seleste childScript2;

        for (int i = 0; i < transform.childCount ; i++)
        {
            childTransform1 = transform.GetChild(i);
            childScript1 = childTransform1.GetComponent<Corpo_seleste>();

            for (int h = i + 1; h < transform.childCount; h++)
            {
                childTransform2 = transform.GetChild(h);
                childScript2 = childTransform2.GetComponent<Corpo_seleste>();

                    ForcaGravidade(ref childScript1, ref childScript2);
                
            }

            childScript1.Coordenada += childScript1.Velocidade * escalaVelocidadeExecucao;
        }


    }
}
