using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletPos;

    public Text score;
    public Text killCount;

    int kills = 0;

    public int reloadTime;

    private float time;

    bool canShoot;
    double sc;
    float maxAmmo = 5;
    float ammoUsed = 0;
    // Use this for initialization
    void Start() {
        canShoot = true;
        time = Time.time;
    }

    // Update is called once per frame
    void Update() {

        sc = ((Time.time - time) * 14) + setf();
        // sc += setf();
        killCount.text = kills.ToString();
        score.text = ((int)sc).ToString();


        if (Input.GetButtonDown("Fire1"))
        {



            if (canShoot)
            {
                // if (ammoUsed < maxAmmo)
                {
                    Instantiate(bullet, bulletPos.transform.position, Quaternion.identity);
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
    unsafe
        
    public int setf(int* hasDied)
    {
        if (*hasDied == 0)
        {
            return 30;
            *hasDied = 1;
        }
        else
            return 0;


    }
}

