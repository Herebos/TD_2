using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public TMP_Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		
		if (waveIndex == waves.Length)
		{
			gameManager.EndGame();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			Monster.startHealth += 5;
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.slime);
			yield return new WaitForSeconds(0f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy(GameObject monsterPrefab)
	{
		Instantiate(monsterPrefab, transform.position, Quaternion.Euler(0, -90, 0));
	}

}