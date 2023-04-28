using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleBomb : MonoBehaviour
{
    [SerializeField] private GameObject slicedFruitPrefab;
    [SerializeField] private ParticleSystem splash;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float explosionradius = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }

        FindObjectOfType<GameManager>().onBombHit();
        CreateSlicedFruit();

    }
    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbOnsliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        ParticleSystem splashIns = Instantiate(splash, transform.position + Offset, transform.rotation);

        foreach (var rigidbody in rbOnsliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionradius);

        }

        FindObjectOfType<GameManager>().IncreaseScore(3);

        Destroy(inst, 5f);
        Destroy(splashIns, 2f);
        Destroy(gameObject);

    }

}
