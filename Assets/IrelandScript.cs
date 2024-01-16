using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrelandScript : MonoBehaviour
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

        renderer.material = deselected;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        renderer.material = selected;
        float[] values = ChartManager.ireland;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Ireland", selected);
    }

    private void OnMouseExit()
    {
        renderer.material = deselected;
    }
}
