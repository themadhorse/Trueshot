using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    // Use this for initialization
    public GameObject[] LaserU;
    public GameObject[] LaserD;

    public GameObject Laser;

    int SpawnTime = 15;
    int startPos;
    int toLookAt = 0;

	void Start () {
        // StartCoroutine(justChecking(SpawnTime));
        InvokeRepeating("spawnLaser", 0, 2);
	}
	
    void spawnLaser()
    {
        startPos = (int)Random.Range(0,6);
        while (startPos == toLookAt)
            toLookAt = (int)Random.Range(0,6);

        
        var rotation = Quaternion.LookRotation(LaserU[toLookAt].transform.position - LaserD[startPos].transform.position);
        Instantiate(Laser, LaserD[startPos].transform.position, rotation);
       // Laser.transform.position = LaserD[startPos].transform.position;
      //  Laser.transform.rotation = rotation;
        //- LaserD[startPos].transform.position


    }
    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator justChecking(int a)
    {
        yield return new WaitForSeconds(a);
        Debug.Log(a);
        a--;
        StartCoroutine(justChecking(a));

    }
}
