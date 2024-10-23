using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int xMax, zMax;
    public GameObject pieza;
    public GameObject[,] map;
    public int limit;

    // Start is called before the first frame update
    void Start()
    {
        map = new GameObject[xMax, zMax];
        StartCoroutine("GenMapBasic");
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
        Instantiate(pieza, new Vector3(x, 0, z), Quaternion.identity);
        yield return new WaitForEndOfFrame();
        if (limit > 0)
        {
            int num = Random.Range(0, 100);
            if (num < 25)
                StartCoroutine(GenMapMedium(x, z + 5));
            else if (num < 50)
                StartCoroutine(GenMapMedium(x, z - 5));
            else if (num < 75)
                StartCoroutine(GenMapMedium(x + 5, z));
            else
                StartCoroutine(GenMapMedium(x - 5, z));
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
