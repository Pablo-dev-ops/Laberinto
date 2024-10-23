using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public static Generador gen;
    public int xMax, zMax;
    public GameObject pieza, piezaLaberinto;
    public GameObject[,] map;
    public int limit;

    // Start is called before the first frame update
    void Start()
    {
        gen = this;
        map = new GameObject[xMax, zMax];
        //StartCoroutine("GenMapBasic");
        //StartCoroutine(GenMapMedium(0,0));
        GenerarPrimeraPlanta();
    }
    public IEnumerator GenMapBasic()
    {
        for (int x=0; x<xMax; x++)
        {

            for (int z = 0; z< zMax; z++)
            {
            
                if(Random.Range(0, 100) < 50)
                {
                    Instantiate(pieza, new Vector3(x*5, 0, z*5) , Quaternion.identity);
                    yield return new WaitForEndOfFrame();
                }
            
            }

        }

    }
    public IEnumerator GenMapMedium(int x, int z)
    {
        limit--;
        Transform newPieza = Instantiate(pieza, new Vector3(x, 0, z), Quaternion.identity).transform;
        yield return new WaitForEndOfFrame();
        if (limit > 0)
        {
            bool completo = false;
            int cont = 0;
            while (!completo && cont<50) 
            {
                cont++;
                
                int num = Random.Range(0, 100);
                if (num < 25 && !Physics.Raycast(newPieza.position, newPieza.forward, 6))
                { StartCoroutine(GenMapMedium(x, z + 5)); completo = true; }
                else if (num < 50 && !Physics.Raycast(newPieza.position, newPieza.forward, 6))
                   { StartCoroutine(GenMapMedium(x, z - 5)); completo = true; }
                else if (num < 75 && !Physics.Raycast(newPieza.position, newPieza.right,6))
                   { StartCoroutine(GenMapMedium(x + 5, z)); completo = true; }
                else if (!Physics.Raycast(newPieza.position, newPieza.right,6))
                    {StartCoroutine(GenMapMedium(x - 5, z)); completo = true; }
            }

        }

    }

    public void GenerarPrimeraPlanta()
    {
        PiezaLaberinto newPieza = Instantiate (piezaLaberinto, new Vector3((xMax/2)*5, 0, (zMax/2)*5), Quaternion.identity).GetComponent<PiezaLaberinto>();
        newPieza.n = true; newPieza.s=true; newPieza.e=true; newPieza.w=true;
        newPieza.x = xMax / 2; newPieza.z = zMax / 2;
        map[xMax / 2, zMax / 2] = newPieza.gameObject;
    }

    public void GenerarSiguientePieza(int x, int z) 
    {
        if (map[x, z] == null)
        {
            PiezaLaberinto newPieza = Instantiate(piezaLaberinto, new Vector3((x* 5), 0, (z *5) ), Quaternion.identity).GetComponent<PiezaLaberinto>();
            newPieza.x = x; newPieza.z = z;
            map[x, z] = newPieza.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
