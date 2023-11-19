using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{


    public GameObject theEnemy;
    public int xPos, zPos, enemyCount;
    [SerializeField] int xParam1, xParam2, zParam1, zParam2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(xParam1, xParam2);
            zPos = Random.Range(zParam1, zParam2);

            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(10);
            enemyCount += 1;
        }
    }

}
