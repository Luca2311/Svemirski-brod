using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeprijateljSpawner : MonoBehaviour
{
    public GameObject neprijateljPrefab;
    public float sirina = 10f;
    public float visina = 5f;
    private bool movingDesno = true;
    public float brzina = 5f;
    private float xmax;
    private float xmin;

    //Use this for initialization
    void Start()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 lijevaGranica = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 desnaGranica = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = desnaGranica.x;
        xmin = lijevaGranica.x;
        foreach (Transform child in transform)
        {
            GameObject neprijatelj = Instantiate(neprijateljPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            neprijatelj.transform.parent = child;
        }
    }
    //Update is called once per frame
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(sirina, visina));
    }
    //Update is called once per frame
    private void Update()
    {
        if (movingDesno)
        {
            transform.position += Vector3.right * brzina * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * brzina * Time.deltaTime;
        }
        float desnaGranicaFormacije = transform.position.x + (0.5f * sirina);
        float lijevaGranicaFormacije = transform.position.x - (0.5f * sirina);
        if (lijevaGranicaFormacije < xmin)
        {
            movingDesno = true;
        }
        else if (desnaGranicaFormacije > xmax)
        {
            movingDesno = false;
        }
    }

}
