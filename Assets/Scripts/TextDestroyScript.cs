using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroyScript : MonoBehaviour
{
    private void OnEnable() 
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
