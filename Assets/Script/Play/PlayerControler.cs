using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler instance;
    float _Speed = 5f;
    [SerializeField] Animator _animator;
    int _HP;
    [SerializeField] GameObject Char;

    public int HP { get => _HP; set => _HP = value; }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        HP = 5;
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        RunAnimation();
    }
    public Vector3 PlayerPotision()
    {
        return this.transform.position;
    }
    public void Run()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _Speed * Time.deltaTime, 0, 0);
        transform.Translate(0, Input.GetAxis("Vertical") * _Speed * Time.deltaTime, 0);
        if (Input.GetAxis("Horizontal") > 0)
        {
            Char.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Char.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void RunAnimation()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
        {
            _animator.SetFloat("IsMove", 1);
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            _animator.SetFloat("IsMove", 0);
        }

    }
    public void GetHit()
    {
        HP--;
        Debug.Log("hit");
        if(HP<=0)
        {
            Die();
        }
    }
    void Die()
    {
        _animator.SetBool("IsDie", true);
        
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetHit();
        }

    }
}
