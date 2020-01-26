using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthbar;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if(Input.GetKeyDown("space"))
        {
            //Instantiate(bullet, this.transform.position, Quaternion.identity);
            GameObject b =  Pool.singleton.Get("bullet");
            if(b != null)
            {
                b.transform.position = this.transform.position;
                b.SetActive(true);
            }
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) + 
                                   new Vector3(0,-70,0);
        healthbar.transform.position = screenPos;
    }
}