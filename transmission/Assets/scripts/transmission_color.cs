using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class transmission_color : MonoBehaviour {
    
    [SerializeField] GameObject wave;
    SpriteRenderer render_transmission;
    Vector3 pos;
    bool encounter = false, wave_on_transmit = false;
    float i = 0.5f;

    private void Awake()
    {
      render_transmission = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        pos = gameObject.transform.position;
      //  Debug.Log(pos);
        callwave();
    }

    private void callwave()
    {
        Instantiate(wave, pos, Quaternion.identity);
    }
   
}
