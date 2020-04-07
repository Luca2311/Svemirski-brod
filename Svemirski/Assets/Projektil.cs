using System.Collections;
using UnityEngine;

public class PonasanjeNeprijatelja : MonoBehaviour
{
    public float snaga = 150;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projektil missile = collider.gameObject.GetComponent<Projektil>();
        if (missile)
        {
            missile.Hit();
            snaga -= missile.GetDamage();
            if (snaga <= 0)
                Destroy(gameObject);
        }
    }

}
