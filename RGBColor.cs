using UnityEngine;
using System.Collections;

public class RGBColor : MonoBehaviour {
    [Range(0, 1)]
    public float r;
    [Range(0, 1)]
    public float g;
    [Range(0, 1)]
    public float b;
    [Range(0, 1)]
    public float a;
    [Range(0, 50)]
    public float blinkSpeed;

    public bool blink = false;
    public bool random = false;
    bool needRandom = false;

    float r2;
    float g2;
    float b2;
    float count = 0;
	// Use this for initialization
	void Start () {
        a = 1;
        blinkSpeed = 100;
        newRandom();
        gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
	}
	
	// Update is called once per frame
	void Update () {
        if (blink == true && count >= 1)
        {
            random = false;
            gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), a);
            count = 0;
            needRandom = false;
        }
        else if (random == true)
        {
            if (needRandom == false)
            {
                newRandom();
            }
            blink = false;
            needRandom = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(r2, g2, b2, a);
        }
        else if(blink != true && random != true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b, a);
            needRandom = false;
        }
        count += Time.deltaTime * blinkSpeed;
	}

    void newRandom()
    {
        r2 = Random.Range(0.0f, 1.0f);
        g2 = Random.Range(0.0f, 1.0f);
        b2 = Random.Range(0.0f, 1.0f);
    }

    
}
