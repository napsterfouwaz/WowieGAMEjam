using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public int Direction = 1;
    bool CanMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Walk1Step()
    {
        if (Direction == 1)
        {
            if (CanMove == true)
            {
                CanMove = false;
                Player.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                yield return new WaitForSeconds(0.5f);
                CanMove = true;
                StartCoroutine(Walk1Step());
            }
        }
        if (Direction == 2)
        {
            if (CanMove == true)
            {
                CanMove = false;
                Player.transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.5f);
                CanMove = true;
                StartCoroutine(Walk1Step());
            }
        }
        if (Direction == 3)
        {
            if (CanMove == true)
            {
                CanMove = false;
                Player.transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.5f);
                CanMove = true;
                StartCoroutine(Walk1Step());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("YOOOOOOOOOOOOOOOOOO");
        if (collision.gameObject.tag == "RightDirection")
        {
            Direction = 2;
        }
        if (collision.gameObject.tag == "LeftDirection")
        {
            Direction = 3;
        }
        if (collision.gameObject.tag == "ForwardDirection")
        {
            Direction = 1;
        }
    }

    public void WasSoup()
    {
        StartCoroutine(Walk1Step());
    }
}
