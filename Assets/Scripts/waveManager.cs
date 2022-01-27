using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class waveManager : MonoBehaviour
{
    public TextMeshProUGUI kills, wave;
    public Transform MinPosition, MaxPositon;
    public List<GameObject> enemies, loot,props;
    public AnimationCurve enemyRate,propNumber;
    public float spawnDelay;
    public int currentWave,currentKills;
    public int currentEnemiesALive;
    int enemyAmount, lootAmount;
 
    private void Start()
    {
        kills?.SetText("KILLS: " + currentKills.ToString());
        wave?.SetText("WAVE: " + currentWave.ToString());
        StartCoroutine(spawn());
    }
    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        currentWave += 1;

            enemyAmount = (int)enemyRate.Evaluate(currentWave);
            spawnEnemies();
            spawnLoot();
            wave?.SetText("WAVE: " + currentWave.ToString());

    }
    public void spawnEnemies()
    {
        int count = 0;
        while (count < enemyAmount)
        {
            float x = Random.Range(MinPosition.position.x, MaxPositon.position.x);
            float y = Random.Range(MinPosition.position.y, MaxPositon.position.y);
            float z = Random.Range(MinPosition.position.z, MaxPositon.position.z);
            Vector3 pos = new Vector3(x, y, z);
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Count)],pos,Quaternion.identity);
            enemy.GetComponent<CharacterStats>().onCharacterDeath += WaveManager_onCharacterDeath;
            count += 1;
            currentEnemiesALive += 1;
        }
        
    }

    private void WaveManager_onCharacterDeath(object sender, CharacterStats.onCharacterDeathArgs e)
    {
        currentEnemiesALive -= 1;
        currentKills += 1;
        kills?.SetText("KILLS: " + currentKills.ToString());
        if (currentEnemiesALive <= 0)
        {
            StartCoroutine(spawn());
        }
    }

    public void spawnLoot()
    {
        int rand = Random.Range(0, loot.Count - 1);
        

            Vector3 pos = player.instance.transform.position + Vector3.forward*2;
        Instantiate(loot[rand], pos, Quaternion.identity);
        int propCount = (int)propNumber.Evaluate(currentWave);
        for (int i = 0; i < propCount; i++)
        {
            float x = Random.Range(MinPosition.position.x, MaxPositon.position.x);
            float y = Random.Range(MinPosition.position.y, MaxPositon.position.y);
            float z = Random.Range(MinPosition.position.z, MaxPositon.position.z);
             pos = new Vector3(x, y, z);

            Instantiate(props[Random.Range(0, props.Count)], pos, Quaternion.identity);
        }
        
        }
}
