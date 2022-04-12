using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAd : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked!");
        anim.SetTrigger("triggerDeathAnimation");
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
