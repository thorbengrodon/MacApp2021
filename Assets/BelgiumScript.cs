using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BelgiumScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject belgiumGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;
    TMP_Text label2;
    TMP_Text label3;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();

        belgiumGraph = GameObject.Find("BelgiumFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("belgiumLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("belgiumLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("belgiumLabel3").GetComponent<TMP_Text>();
        label3.text = "";

        Renderer[] renderers = belgiumGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        Scene scene = SceneManager.GetActiveScene();
        string name = scene.name;

        if (string.Equals(name, "Dataset2021"))
        {
            label1.text = ChartManager.belgiumLuxembourg_netherlands[0].ToString() + " GWH";
            label2.text = ChartManager.belgiumLuxembourg_germany[0].ToString() + " GWH";
            label3.text = ChartManager.belgiumLuxembourg_france[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.belgiumLuxembourg_netherlands[0].ToString() + " GWH";
            label2.text = ChartManager2010.belgiumLuxembourg_germany[0].ToString() + " GWH";
            label3.text = ChartManager2010.belgiumLuxembourg_france[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.belgiumLuxembourg_netherlands[0].ToString() + " GWH";
            label2.text = ChartManager2000.belgiumLuxembourg_germany[0].ToString() + " GWH";
            label3.text = ChartManager2000.belgiumLuxembourg_france[0].ToString() + " GWH";
        }




        renderer.material = selected;
        Renderer[] renderers = belgiumGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.belgium_luxembourg;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Belgium-Luxemburg", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";

        renderer.material = deselected;
        Renderer[] renderers = belgiumGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
