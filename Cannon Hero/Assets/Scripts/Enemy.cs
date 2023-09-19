using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer EnemySprite;
    public Sprite EnemyDead;
    public Rigidbody2D EnemyRigid;
    public float speed;
    [SerializeField] private BoxCollider2D EnemyCollider;
    [SerializeField] private Gun gun;

    private GameObject level;
    private GameObject player;
    private float targetAngle;
    private bool isAiming;
    public bool Dead { get; set; }

    public void Renew()
    {
        isAiming = false;
        Dead = false;
        EnemyCollider.enabled = true;
        gun.Renew();
    }

    private void Awake()
    {
        level = transform.parent.gameObject;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GamePlay.isPlaying)
            return;

        if (!GamePlay.isEnemyTurn)
            return;

        if (!isAiming)
        {
            transform.rotation = Quaternion.identity;
            gun.transform.rotation = Quaternion.identity;
            isAiming = true;

            // calculate target angle
            float x = transform.position.x - player.transform.position.x;
            float y = transform.position.y - player.transform.position.y;
            targetAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        }

        if (isAiming)
            Aiming();
    }

    private void Aiming()
    {
        gun.Aiming();

        if (gun.transform.eulerAngles.z >= Mathf.Abs(targetAngle))
            StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        isAiming = false;
        GamePlay.isEnemyTurn = false;

        float timeWaitToFire = 0.05f;
        yield return new WaitForSeconds(timeWaitToFire);
        gun.Fire();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("PlayerBullet"))
        {
            Debug.Log("trigg");
            EnemyRigid.AddForce(transform.up * 5, ForceMode2D.Impulse);
            EnemySprite.sprite = EnemyDead;
            EnemyCollider.enabled = false;
            Player.Instance.UpdatePlayerPos();
        }
        if (collision.gameObject.transform.CompareTag("Ground"))
        {
           // gameObject.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("Level"))
        {
            //gameObject.SetActive(false);
        }
    }
}