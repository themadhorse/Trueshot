using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject[] bulletPos;

    public Text score;
    public Text killCount;

    int kills = 0;

    public int reloadTime;

    private float time;

    int isDead = 1;

    bool canShoot;
    float sc;
    float maxAmmo = 5;
    float ammoUsed = 0;

    bool buckshot = false;
    // Use this for initialization
    void Start() {
        canShoot = true;
        time = Time.time;
    }

    // Update is called once per frame
    void Update() {

        sc = (Time.time - time);
        // sc += setf();
        killCount.text = kills.ToString();
        score.text = (Mathf.Round(sc * 1000.0f) / 1000.0f).ToString();


        if (Input.GetButtonDown("Fire1"))
        {



            if (canShoot)
            {
               /* if(buckshot)
                {
                    Vector3 rot = bulletPos[1].transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x, rot.y, rot.z + 10);
                    

                    Vector3 rot1 = bulletPos[1].transform.rotation.eulerAngles;
                    rot1 = new Vector3(rot1.x, rot1.y, rot1.z - 10);
                   

                    Instantiate(bullet, bulletPos[0].transform.position, Quaternion.identity);
                    Instantiate(bullet, bulletPos[1].transform.position, Quaternion.Euler(rot));
                    Instantiate(bullet, bulletPos[2].transform.position, Quaternion.Euler(rot1));
                }
                else*/
                {
                    Instantiate(bullet, bulletPos[0].transform.position, Quaternion.identity);
                 
                    // Rigidbody2D rd = bullet.GetComponent<Rigidbody2D>();
                    // rd.AddForce(gameObject.transform.forward * 1000 * Time.deltaTime);
                    ammoUsed++;
                }
                canShoot = false;
                StartCoroutine(Reload());
            }


        }

    }

    public float getAmmoUsed()
    {
        return ammoUsed;
    }

    public void setAmmoUsed(float x)
    {
        ammoUsed = x;
    }

    public int getKills()
    {
        return kills;
    }

    public void setKills(int y)
    {
        kills = y;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;

        yield return null;
    }
    public void setIsDead(int a)
    {
        isDead = a;
    }
        
    public int getAddedScore(int hasDied)
    {
        if (hasDied == 0)
        {
            return 30;
            hasDied = 1;
        }
        else
            return 0;


    }

    public void setCanShoot(bool paused)
    {
        canShoot = paused;
    }

    public void setBuckshot()
    {
        buckshot = true;
    }

    public bool getBuckShot()
    {
        return buckshot;
    }
}

