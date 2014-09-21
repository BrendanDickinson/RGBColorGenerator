using UnityEngine;
using System.Collections;

public class RGBColor : MonoBehaviour 
{
    [Range(0.0f, 1)]
    public float r;
    [Range(0.0f, 1.0f)]
    public float g;
    [Range(0.0f, 1.0f)]
    public float b;
    [Range(0.0f, 1.0f)]
    public float a;
    [Range(0.0f, 50.0f)]
    public float blinkSpeed;

    public bool blink = false;
    public bool random = false;
    private bool needRandom = false;
	

    private float r2;
    private float g2;
    private float b2;
    private float count = 0;
	
	// Cache 
	private Renderer rendererCache = null;
	
	// Use this for initialization
	void Start() 
	{
        a = 1.0f;
        blinkSpeed = 100.0f;
        newRandom();
		rendererCache = gameObject.renderer;
        rendererCache.material.shader = Shader.Find("Transparent/Diffuse");
	}
	
	// Update is called once per frame
	void Update()
	{
        if (blink == true && count >= 1)
        {
            random = false;
            rendererCache.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), a);
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
            rendererCache.material.color = new Color(r2, g2, b2, a);
        }
        else if(blink == false && random == false)
        {
            rendererCache.material.color = new Color(r, g, b, a);
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
