using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{

    public Color selected;
    public Color deselected;
    // Start is called before the first frame update
    void Start()
    {
        selected = Color.yellow;
        deselected = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
