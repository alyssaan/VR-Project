using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject _caption;

    [SerializeField] private GameObject sparrow;
    [SerializeField] private GameObject squid;
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject monkey;
    [SerializeField] private GameObject gecko;
    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject muskrat;
    [SerializeField] private GameObject deer;

    // Start is called before the first frame update
    void Start()
    {
        _caption.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject target = hit.collider.gameObject;

            if (target != null)
            {
                if (target == npc)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Wave");
                        StartCoroutine(DisplayCaption(5f));
                    }
                }
                if (target == sparrow)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == squid)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == snake)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == monkey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == gecko)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == fish)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == muskrat)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
                if (target == deer)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        target.GetComponent<Animator>().SetTrigger("Interact");
                    }
                }
            }
        }
    }

    // this is a co-routine by the way
    private IEnumerator DisplayCaption(float duration)
    {
        // IEnumerator type is something that happens over multiple frames
        // (array of possible things and then enumerating through them)

        _caption.SetActive(true);

        yield return new WaitForSeconds(duration);

        _caption.SetActive(false);
    }
}