using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public int alto;
    public int ancho;
    public int largo;
    public static Generador gen;
    public GameObject cubo;
    public GameObject[,,] map;

    public float detail;
    public int seed;

    void Start()
    {
        /*
        gen = this;
        map = new GameObject[ancho, alto, largo];
        
        // Generar las tres figuras
        GenerarPiramide();
        GenerarCubo();
        GenerarPendiente();
        */

        GenerateMap();
    }

    void Update()
    {
    }

    public void generateMap()
    {
    }

 void GenerarPiramide()
    {
        int centroX = ancho / 2;
        int centroZ = largo / 2;

        for (int y = 0; y < alto; y++)
        {
            int nivel = alto - y - 1;
            for (int x = centroX - nivel; x <= centroX + nivel; x++)
            {
                for (int z = centroZ - nivel; z <= centroZ + nivel; z++)
                {
                    if (x >= 0 && x < ancho && z >= 0 && z < largo)
                    {
                        map[x, y, z] = Instantiate(cubo, new Vector3(x, y, z), Quaternion.identity);
                        Cubo cuboComponent = map[x, y, z].GetComponent<Cubo>();
                        if (cuboComponent != null)
                        {
                            cuboComponent.x = x;
                            cuboComponent.y = y;
                            cuboComponent.z = z;
                        }
                    }
                }
            }
        }
    }

    void GenerarCubo()
    {
        for (int i = 0; i < ancho; i++)
        {
            for (int j = 0; j < alto; j++)
            {
                for (int k = 0; k < largo; k++)
                {
                    map[i, j, k] = Instantiate(cubo, new Vector3(i + ancho + 2, j, k), Quaternion.identity);
                    Cubo cuboComponent = map[i, j, k].GetComponent<Cubo>();
                    if (cuboComponent != null)
                    {
                        cuboComponent.x = i;
                        cuboComponent.y = j;
                        cuboComponent.z = k;
                    }
                }
            }
        }
    }

    void GenerarPendiente()
    {
        for (int i = 0; i < ancho; i++)
        {
            for (int j = 0; j < alto; j++)
            {
                for (int k = 0; k < largo; k++)
                {
                    if (j <= i)
                    {
                        map[i, j, k] = Instantiate(cubo, new Vector3(i + 2 * (ancho + 2), j, k), Quaternion.identity);
                        Cubo cuboComponent = map[i, j, k].GetComponent<Cubo>();
                        if (cuboComponent != null)
                        {
                            cuboComponent.x = i;
                            cuboComponent.y = j;
                            cuboComponent.z = k;
                        }
                    }
                }
            }
        }
    }

    public void GenerateMap(){
        for(int i=0; i<ancho; i++){
            for(int j=0; j<largo; j++){

                alto = (int)(Mathf.PerlinNoise((i/2+seed)/detail, (j/2+seed)/detail)*detail);
                for(int k=0; k<alto; k++){
                    Instantiate(cubo, new Vector3(i,k,j), Quaternion.identity);
                }
            }
        }
    }
}
