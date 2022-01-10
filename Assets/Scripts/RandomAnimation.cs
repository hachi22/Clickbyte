using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAnimation() {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        int numRandom = Random.Range(2, 9);
        animator.SetInteger("animation_id", numRandom);
        animator.SetFloat("Blend", numRandom);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.25f);

        //After we have waited 5 seconds print the time again.
        animator.SetInteger("animation_id", 1);
        animator.SetFloat("Blend", 0);
    }
}
