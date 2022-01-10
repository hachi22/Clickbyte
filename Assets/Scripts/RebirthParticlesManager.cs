using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthParticlesManager : MonoBehaviour
{
    [SerializeField] GameObject clickEffect;
    private Vector2 mousePos;
    [SerializeField] GameObject canvas;
    public bool heartsRebirth = false;

    private void Start()
    {
        if (PlayerPrefs.GetInt("heartsRebirth", 0) == 1)
        {
            heartsRebirth = true;
        }
        else
        {
            heartsRebirth = false;
        }
            
    }
    void Update()
    {
        if(heartsRebirth)
        hearts();
    }

    private void hearts()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject go = Instantiate(clickEffect);
            go.transform.SetParent(canvas.transform);
            go.transform.position = new Vector2(mousePos.x, mousePos.y);
            Destroy(go,1);
            
           
        }
    }
}
