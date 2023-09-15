using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    private Enemy enemy;
    private BoxCollider2D bodyCollider;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        bodyCollider = transform.GetComponent<BoxCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("PlayerBullet"))
        {
            Debug.Log("Trigg");
            gameObject.SetActive(false);
        }
    }
}