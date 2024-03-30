using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject _caption;


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
                    if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
                    {
                        target.GetComponent<Animator>().SetTrigger("Wave");
                        StartCoroutine(DisplayCaption(5f));
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
