using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] float _speed = 2.0f;
    public static Enemy Instance;

    // Start is called before the first frame update
    void Start()
    {
        
        if(Instance == null)
        {
            Instance= this;
        }
        animator = GetComponent<Animator>();
        _speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        FolowPlayer();
    }
    public void FolowPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerControler.instance.PlayerPotision(), _speed * Time.deltaTime);

    }
    public void Attack()
    {
        animator.SetTrigger("Hit");
    }
    public void GetHit()
    {
        animator.SetBool("IsDie", true);
        _speed = 0;
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        GameManager.instance.EnemyScore();
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            GetHit();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Attack();
        }
    }
}
