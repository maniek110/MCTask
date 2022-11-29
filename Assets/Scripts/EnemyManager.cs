using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemuPrefab;
    public GameObject Player;

    Dictionary<GameObject, bool> Enemies = new Dictionary<GameObject, bool>(); 
    GameObject[] EnemyArray;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        EnemyArray = new GameObject[1000];
        for (int i = 0; i < 1000; i++)
        {
            GameObject enemy = GameObject.Instantiate(EnemuPrefab);
            enemy.transform.position = getRandomPos();
            enemy.name = "Enemy " + i;
            Enemies.Add(enemy,true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<GameObject,bool> pair in Enemies) {

            if (CanMove(pair.Key.transform.position) == true && pair.Value)
            {
                pair.Key.transform.Translate((pair.Key.transform.position - Player.transform.position).normalized * Time.deltaTime);
            }
        }
    }

    internal void StopEnemy(GameObject gameObject)
    {
        Enemies[gameObject] = false;
    }

    private bool CanMove(Vector3 position)
    {
        var viewportPosition = camera.WorldToViewportPoint(position);
        if ((viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            return false;
        }

        if ((viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            return false;
        }

        return true;
    }

    private Vector2 getRandomPos()
    {
        float spawnY = Random.Range
                   (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        return new Vector2(spawnX, spawnY);
    }
}
