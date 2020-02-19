using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterKaboom : MonoBehaviour {

    // Use this for initialization
    public int AfterExplo;

    public GameObject ToDie;

	void Start () {
        StartCoroutine(Dead());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("The End");
        }
    }   

    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(AfterExplo);

        Destroy(ToDie.gameObject);

        yield return null;
    }
}
