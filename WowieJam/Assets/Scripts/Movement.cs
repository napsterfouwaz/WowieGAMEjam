using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public int Direction = 1;
    bool CanMove = true;
    public Animator animes;
    Vector3 StartPos;
    public GameObject Image;
    public AudioClip Dies;
    public AudioClip Change;
    public AudioClip Teleport;
    public AudioClip Walk;
    public AudioSource yes;
    public BoxCollider2D Collid;
    public AudioClip win;
    bool CanLose = true;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Walk1Step()
    {
        Collid.enabled = true;
        yes.PlayOneShot(Walk);
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
        if (Direction == 4)
        {
            if (CanMove == true)
            {
                CanMove = false;
                Player.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
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
            yes.PlayOneShot(Change);
        }
        if (collision.gameObject.tag == "LeftDirection")
        {
            yes.PlayOneShot(Change);
            Direction = 3;
        }
        if (collision.gameObject.tag == "ForwardDirection")
        {
            yes.PlayOneShot(Change);
            Direction = 1;
        }
        if (collision.gameObject.tag == "DownDirection")
        {
            yes.PlayOneShot(Change);
            Direction = 4;
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (CanLose == true)
            {
                StartCoroutine(Die());
            }
        }
        if (collision.gameObject.tag == "WinTile")
        {
            StartCoroutine(Wins());
        }
    }

    public void WasSoup()
    {
        StartCoroutine(Walk1Step());
    }

    public IEnumerator Die()
    {
        CanMove = false;
        Collid.enabled = false;
        yes.PlayOneShot(Dies);
        Image.SetActive(true);
        animes.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator Wins()
    {
        Player.GetComponent<SpriteRenderer>().enabled = false;
        CanLose = false;
        CanMove = false;
        Collid.enabled = false;
        yes.PlayOneShot(win);
        Image.SetActive(true);
        animes.SetTrigger("Fade");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
