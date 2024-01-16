using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FranceScript : MonoBehaviour
{
    Renderer renderer;
    Material selected;
    Material deselected;

    GameObject franceGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;
    TMP_Text label2;
    TMP_Text label3;
    TMP_Text label4;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");

        franceGraph = GameObject.Find("FranceFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("franceLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("franceLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("franceLabel3").GetComponent<TMP_Text>();
        label3.text = "";
        label4 = GameObject.Find("franceLabel4").GetComponent<TMP_Text>();
        label4.text = "";

        Renderer[] renderers = franceGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.france_spain[0].ToString() + " GWH";
            label2.text = ChartManager.france_italy[0].ToString() + " GWH";
            label3.text = ChartManager.france_germay[0].ToString() + " GWH";
            label4.text = ChartManager.france_belgium[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.france_spain[0].ToString() + " GWH";
            label2.text = ChartManager2010.france_italy[0].ToString() + " GWH";
            label3.text = ChartManager2010.france_germay[0].ToString() + " GWH";
            label4.text = ChartManager2010.france_belgium[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.france_spain[0].ToString() + " GWH";
            label2.text = ChartManager2000.france_italy[0].ToString() + " GWH";
            label3.text = ChartManager2000.france_germay[0].ToString() + " GWH";
            label4.text = ChartManager2000.france_belgium[0].ToString() + " GWH";
        }


        renderer.material = selected;

        Renderer[] renderers = franceGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.france;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "France", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";
        label4.text = "";

        renderer.material = deselected;

        Renderer[] renderers = franceGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
