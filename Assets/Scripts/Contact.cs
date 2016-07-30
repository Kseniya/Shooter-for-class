using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour
{

    public GameObject explosion;

    GameController gameController;

    void Start ()
    {
        gameController = FindObjectOfType<GameController> ();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Frame" || other.tag == "Enemy") {
            return;
        }

        if (other.tag == "Player") {
            gameController.GameOver ();
        }

        Instantiate (explosion, other.transform.position, other.transform.rotation);

        gameController.AddScore ();
        Destroy (other.gameObject);
        Destroy (gameObject);
    }
}
