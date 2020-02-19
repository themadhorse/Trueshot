using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

   

    // Use this for initialization
     Vector3 target;
    public float speed = 12.0f;
    
    private Shoot shoot;

    int i = 0;

    




    void Start()
    {
        
        shoot = GameObject.FindWithTag("Weapon").GetComponent<Shoot>();
        target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        target.z = 0;
        target.Normalize();
    }

    void Update()
    {
        
        transform.position = transform.position + (target * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag != "Player" && other.transform.tag != "ExplosionRange")
        {
            Destroy(this.gameObject);
            
        }
        if(other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
            shoot.setAmmoUsed(shoot.getAmmoUsed() - 1f);
            
            
            shoot.setKills(shoot.getKills()+1);
            shoot.setf(&i);
        }
        
    }

}
