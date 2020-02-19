using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaboomDetection : MonoBehaviour {

    public GameObject radR;

    public int ChangeTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeToRed());
        }
    }

    private IEnumerator ChangeToRed()
    {
        yield return new WaitForSeconds(ChangeTime);

        this.gameObject.SetActive(false);

        radR.gameObject.SetActive(true);

        yield return null;
    }
}
