using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemuPrefab;
    public GameObject Player;

    GameObject[] EnemyArray;
    Vector2 screenBottomLeft = Vector2.zero;
    Vector2 screenTopRight = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
        EnemyArray = new GameObject[1000];
        for (int i = 0; i < EnemyArray.Length; i++)
        {
            EnemyArray[i] = GameObject.Instantiate(EnemuPrefab);
            EnemyArray[i].transform.position = getRandomPos();
        }

    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < EnemyArray.Length; i++)
        {
            EnemyArray[i].transform.position = Vector2.Lerp(gameObject.transform.position, -Player.transform.position, Time.deltaTime*0.01f );
        }
    }

    private Vector2 getRandomPos()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(screenBottomLeft.x,screenTopRight.x), Random.Range(screenBottomLeft.y,screenTopRight.y), 0));
    }
}
