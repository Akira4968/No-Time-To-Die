using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _Speed = 5.0f;
    [SerializeField] Rigidbody2D _Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Rigidbody.velocity = transform.right * _Speed;
        Destroy(this.gameObject, 10);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        
    }

}
