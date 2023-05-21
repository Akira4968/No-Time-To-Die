using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Transform _transform;
    [SerializeField] GameObject _Bullet;
    [SerializeField] Transform _Firepoint;
    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        LAMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _transform.rotation = rotation;
    }
    public void Fire()
    {
        Instantiate(_Bullet,_Firepoint.position,_Firepoint.rotation);
    }
}
