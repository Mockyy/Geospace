using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobspawn : MonoBehaviour
{
    public GameObject spawnObject;
    public float respawnTime;
    private Vector2 screenBounds; 

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(MobWave());
    }
    
    private void SpawnEnemy()
    {
        GameObject a = Instantiate(spawnObject) as GameObject;
        a.transform.position = new Vector2(
            Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y );
    }

    IEnumerator MobWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
