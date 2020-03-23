using UnityEngine;
using System.Collections;

namespace TDGP.Demo
{
/// <summary>
/// Spawns enemies for the example scene.
/// </summary>
	public class EnemySpawner : MonoBehaviour
	{
		/// <summary>
		/// The enemy prefab.
		/// </summary>
		public GameObject[] Enemy;

        public GameObject spawnPoint;
        public GameObject ps;

		/// <summary>
		/// Time between spawns.
		/// </summary>
		public float SpawnTime = 2f;

		/// <summary>
		/// The maximum number of enemies on screen.
		/// </summary>
		public int MaxEnemiesOnScreen = 10;
        int enemyNo = 0;
		/// <summary>
		/// Reference to the kill text.
		/// </summary>
		public KillCount KillCount;

        public GameObject EnemyP;
		private int currentEnemyCount = 0;

		void Start ()
		{
			InvokeRepeating ("SpawnEnemy", 0f, SpawnTime);
            
		}

		/// <summary>
		/// Updates kill count.
		/// </summary>
		public void EnemyRemoved ()
		{
			currentEnemyCount--;
			KillCount.EnemyKilled ();
		}

		private void SpawnEnemy ()
		{
			if (currentEnemyCount >= MaxEnemiesOnScreen)
				return;
			
			currentEnemyCount++;
            //var position = new Vector2 (Random.Range (-8, 8), Random.Range (2, 4));
            
            ps.transform.position = new Vector2(Random.Range(-8,8), Random.Range(2,4));
           
            
            
            ps.GetComponent<ParticleSystem>().Play();
            StartCoroutine(SpawnDelay());
            
          //  Enemy[enemyNo].GetComponent<ParticleSystem>().enableEmission = true;
            //Instantiate (Enemy, position, Quaternion.identity);
            
		}

        private IEnumerator SpawnDelay()
        {
            yield return new WaitForSeconds(1);
            Enemy[enemyNo] = Instantiate(EnemyP);
            
            Enemy[enemyNo].transform.position = ps.transform.position;
            
            enemyNo++;
            ps.GetComponent<ParticleSystem>().Stop();
        }
	}

    
}
