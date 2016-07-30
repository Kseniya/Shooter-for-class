using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControl : MonoBehaviour
{

    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update ()
    {
        if (Input.GetButton ("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource> ().Play ();
        }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        Rigidbody2D body = GetComponent<Rigidbody2D> ();

        if (body != null) {
            body.velocity = movement * speed;
        }

        body.position = new Vector2
        (
            Mathf.Clamp (body.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp (body.position.y, boundary.yMin, boundary.yMax)
        );
    }
}
