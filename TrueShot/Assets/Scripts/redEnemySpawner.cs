using UnityEngine;
using System.Collections;

namespace TDGP.Demo
{
    /// <summary>
    /// Spawns enemies for the example scene.
    /// </summary>
    public class redEnemySpawner : MonoBehaviour
    {
        /// <summary>
        /// The enemy prefab.
        /// </summary>
        public GameObject[] Enemy;

        public GameObject spawnPoint;
        public GameObject EnemyR;

        public GameObject ps;

        /// <summary>
        /// Time between spawns.
        /// </summary>
         float SpawnTime = 6f;

        /// <summary>
        /// The maximum number of enemies on screen.
        /// </summary>
        public int MaxEnemiesOnScreen = 10;
        int enemyNo= 0;
        /// <summary>
        /// Reference to the kill text.
        /// </summary>
        public KillCount KillCount;
        

        private int currentEnemyCount = 0;

        void Start()
        {
            //InvokeRepeating("SpawnEnemy", 0f, SpawnTime);
           // StartCoroutine(SpawnTimer(SpawnTime));
            
        }

        /// <summary>
        /// Updates kill count.
        /// </summary>
        public void EnemyRemoved()
        {
            currentEnemyCount--;
            KillCount.EnemyKilled();
        }

        private void SpawnEnemy()
        {
            if (currentEnemyCount >= MaxEnemiesOnScreen)
                return;

            currentEnemyCount++;
            //var position = new Vector2 (Random.Range (-8, 8), Random.Range (2, 4));
            
            int a;
            a = Random.Range(1, 3);
            if(a == 1)
                ps.transform.position = new Vector2(-8.5f, Random.Range(-4, 4));
            else
                ps.transform.position = new Vector2(8.5f, Random.Range(-4, 4));
            
            
            ps.GetComponent<ParticleSystem>().Play();
            StartCoroutine(SpawnDelay());
           
            //Instantiate (Enemy, position, Quaternion.identity);
            

        }

        private IEnumerator SpawnDelay()
        {
            yield return new WaitForSeconds(1);
            Enemy[enemyNo] = Instantiate(EnemyR);
            Enemy[enemyNo].transform.position = ps.transform.position;
            enemyNo++;
            ps.GetComponent<ParticleSystem>().Stop();
        }

        private IEnumerator SpawnTimer(float a)
        {
            yield return new WaitForSeconds(a);
            SpawnEnemy();

            if(a > 2.5f)
            a -= 0.075f;

            StartCoroutine(SpawnTimer(a));

        }
    }
}