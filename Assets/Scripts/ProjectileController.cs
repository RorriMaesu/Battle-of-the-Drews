using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public bool left;
    float timer = 0f;

    [SerializeField]
    string characterName;

    [SerializeField]
    BoxCollider boxCol;

    void OnEnable()
    {
        StartCoroutine(EnableCollider());
    }

    void Update()
    {
        if(left)
        {
            gameObject.transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
        }
        else
        {
            gameObject.transform.position += new Vector3(10 * Time.deltaTime, 0, 0);
        }

        timer += Time.deltaTime;

        if(timer > 5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if((collider.gameObject.tag == "Player" || collider.gameObject.tag == "AI") &&
            collider.gameObject.name != characterName)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.2f);
        boxCol.enabled = true;
    }
}
