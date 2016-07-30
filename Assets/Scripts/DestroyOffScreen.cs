using UnityEngine;
using System.Collections;

public class DestroyOffScreen : MonoBehaviour
{
    void OnTriggerExit2D (Collider2D other)
    {
        Destroy (other.gameObject);
    }
}
