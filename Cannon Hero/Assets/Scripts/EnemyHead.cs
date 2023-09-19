using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    private Enemy enemy;
    private BoxCollider2D headCollider;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        headCollider = transform.GetComponent<BoxCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("PlayerBullet"))
        {
            //Debug.Log("Trigg");
            //gameObject.SetActive(false);
        }
    }
}