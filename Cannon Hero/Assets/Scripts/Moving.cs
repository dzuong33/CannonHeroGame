using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 2.5f;
    private float leftSide, randX;

    [SerializeField] private Vector2 left, right;
    public void Start()
    {
        randX = Random.Range(left.x, right.x);
        leftSide = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        Update(randX);
    }

    private void Update(float randX)
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= randX)
        {

            //speed = 0;
            
        }
    }
}
