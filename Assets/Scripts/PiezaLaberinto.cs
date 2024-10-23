using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaLaberinto : MonoBehaviour
{
    public int x, z, chance;
    public bool n, s, e, w;

    // Start is called before the first frame update
    void Start()
    {
        #region Generacion aleatoria de salidas
        int num = Random.Range(0, 100);
        if (num < chance && z < Generador.gen.zMax-1)
            n = true;
        num=Random.Range(0, 100);
        if (num < chance&& z>0)
            s = true;
        num = Random.Range(0, 100);
        if (num < chance && x < Generador.gen.xMax-1) 
            e = true;
        num= Random.Range(0, 100);
        if(num < chance && x>0)
            w = true;
        #endregion
        GenerarVecino();
        #region
        if (z < Generador.gen.zMax - 1 && Generador.gen.map[x, z + 1] != null)
            n = true;
        if (z <0 && Generador.gen.map[x, z + 1] != null)
            s = true;
        if (x < Generador.gen.xMax - 1 && Generador.gen.map[x+1, z] != null)
            e = true;
        if (x < 0 && Generador.gen.map[x-1, z ] != null)
            w = true;
        #endregion

        CheckMuros();   
    }

    public void GenerarVecino()
    {
        if (n)
            Generador.gen.GenerarSiguientePieza(x, z + 1);
        if (s)
            Generador.gen.GenerarSiguientePieza(x, z - 1);
        if (e)
            Generador.gen.GenerarSiguientePieza(x + 1, z);
        if (w)
            Generador.gen.GenerarSiguientePieza(x - 1, z);


    }
    public void CheckMuros()
    {
        if (w)
            transform.GetChild(3).gameObject.SetActive(false);
        if (e)
            transform.GetChild(2).gameObject.SetActive(false);
        if (s)
            transform.GetChild(1).gameObject.SetActive(false);
        if (n)
            transform.GetChild(0).gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
