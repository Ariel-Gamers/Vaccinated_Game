using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCell : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float health;
    [SerializeField] float dmg;
    [SerializeField] float time;
    [SerializeField] Vector3 direction;
    [SerializeField] int cost;

    void Start()
    {
        health = 100f;
        dmg = 5f;
        cost = 3;
    }

    public int getCost()
    {
        return cost;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject o = collision.gameObject;
        if (o.tag == "BadCell")
        {
            StartCoroutine(Engaged(o));
        }
        Debug.Log("EnterTrigger");
    }

    private IEnumerator Engaged(GameObject o)
    {
        BadCell c = o.GetComponent<BadCell>();
        while (o != null)
        {
            if (time > 2)
            {
                c.fight(dmg);
                time = 0;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void fight(float dmg)
    {
        health -= dmg;
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
