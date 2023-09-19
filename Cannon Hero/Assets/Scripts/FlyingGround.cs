using UnityEngine;

public class FlyingGround : MonoBehaviour
{

    private void Awake()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }
}