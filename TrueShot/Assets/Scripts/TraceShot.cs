using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceShot : MonoBehaviour {

    public GameObject Tracker;
    public GameObject Player;
    public GameObject Laser;

     int rotateSpeed;

	// Use this for initialization
	void Start () {
        
        Player = GameObject.FindWithTag("Player");
        rotateSpeed = 10;
        StartCoroutine(Shoot(5));
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 vectorToTarget = Player.transform.position - Tracker.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        Tracker.transform.rotation = Quaternion.Slerp(Tracker.transform.rotation, q, Time.deltaTime * rotateSpeed);


	}

   

    private IEnumerator Shoot(float time)
    {
        yield return new WaitForSeconds(time);

        rotateSpeed = 0;
        yield return new WaitForSeconds(1);
        Laser.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        Laser.SetActive(false);

        rotateSpeed = 10;

    }
}
