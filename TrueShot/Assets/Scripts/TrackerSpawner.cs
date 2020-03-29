using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerSpawner : MonoBehaviour {

    float spawnTime = 11f;

    public GameObject tracker;

    public GameObject trackerParticle;

    public GameObject[] Enemy;

    int enemyNo = 0;

	void Start () {
      //  StartCoroutine(SpawnTimer(spawnTime));
	}
	
	private void SpawnEnemy()
    {
        trackerParticle.transform.position = new Vector2(Random.Range(-7.5f,7.5f), 4.83f);

        trackerParticle.GetComponent<ParticleSystem>().Play();
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(1);

        Enemy[enemyNo] = Instantiate(tracker);
        Enemy[enemyNo].transform.position = trackerParticle.transform.position;
        enemyNo++;

        trackerParticle.GetComponent<ParticleSystem>().Stop();
    }

    private IEnumerator SpawnTimer(float a)
    {
        yield return new WaitForSeconds(a);
        SpawnEnemy();

        if (a > 7f)
            a -= 0.5f;

        StartCoroutine(SpawnTimer(a));

    }
}
