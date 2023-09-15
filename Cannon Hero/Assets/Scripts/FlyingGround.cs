using UnityEngine;

public class FlyingGround : MonoBehaviour
{

    private void Awake()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            
        }
    }
}