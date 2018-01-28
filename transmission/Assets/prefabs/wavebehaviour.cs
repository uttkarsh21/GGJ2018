using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wavebehaviour : MonoBehaviour {


    public float maxSize;
    public float growFactor;
    public float waitTime;

    bool wave_on = false;

    public void Start()
    {
        wave_on = true;
        StartCoroutine(Scale());
    }


    IEnumerator Scale()
    {
     //   Debug.Log("start coroutine");
        float timer = 0;

        while (wave_on) // this could also be a condition indicating "alive or dead"
        {
           
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        wave_on = false;
        if(collision.CompareTag("Player"))
        Destroy(this.gameObject);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //  Debug.Log("triggered");
    }
}
