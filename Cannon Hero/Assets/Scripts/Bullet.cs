using UnityEngine;

public class Bullet : MonoBehaviour
{
    
   

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            gameObject.SetActive(false);
        if (collision.gameObject.tag == "Level")
           gameObject.SetActive(false);
    }
}