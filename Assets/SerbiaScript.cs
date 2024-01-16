using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerbiaScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        renderer.material = selected;
        float[] values = ChartManager.serbia;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Serbia", selected);
    }

    private void OnTriggerExit(Collider other)
    {
        renderer.material = deselected;
    }
}
