using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitToSpwnPrefab;
    [SerializeField] private GameObject[] bomb;
    [SerializeField][Range(0f,100f)] private float bombChance;
    [SerializeField][Range(0f,100f)] private float pineappleChance;
    [SerializeField] private Transform[] spawnPlaces;
    [SerializeField] private float minWait;
    [SerializeField] private float maxWait;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [SerializeField] private float fruityDemise;
    public int num= 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(maxWait, minWait));

            Transform t = spawnPlaces[Random.Range(0,spawnPlaces.Length)];

            GameObject go = null;
            float rnd = Random.Range(0, 100);

            if (rnd < bombChance)
            {
                if(rnd< pineappleChance)
                {
                    go = bomb[1];

                }
                else
                {
                    go = bomb[0];

                }
            }
            else
            {
                go = fruitToSpwnPrefab[Random.Range(0, fruitToSpwnPrefab.Length)];
            }


            GameObject fruit = Instantiate(go, t.transform.position, t.transform.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Debug.Log("Spawning Fruits");

            Destroy(fruit, fruityDemise);
        }
    }

    public void suma() 
    {
        num += 1; 
    }



}
