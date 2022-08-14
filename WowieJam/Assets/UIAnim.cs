using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnim : MonoBehaviour
{
    public Animator Fade;
    public GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Die()
    {
        Fade.SetTrigger("DeFade");
        yield return new WaitForSeconds(0.5f);
        Image.SetActive(false);
    }
}
