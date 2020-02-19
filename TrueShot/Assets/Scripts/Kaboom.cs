using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaboom : MonoBehaviour {
    public int blastTime;

    Color newColor;

    public GameObject radiusW;
    public GameObject radiusR;
	// Use this for initialization
	void Start () {
        newColor = new Color(255,140,140);
        //  StartTimer(blastTime);
        // Destroy(this.gameObject);
       // StartCoroutine(StartTimer());
    }
	
	// Update is called once per frame
	void Update () {
       // if (this.gameObject.activeInHierarchy)
           // Debug.Log("Yes");
        
    }

  /*  private IEnumerator StartTimer()
    {
     //   Debug.Log("Atleast function is called");
        yield return new WaitForSeconds(blastTime);
        radiusW.SetActive(false);
        radiusR.SetActive(true);
        //  Destroy(this.gameObject);
        yield return null;
    }*/

   
   
}
