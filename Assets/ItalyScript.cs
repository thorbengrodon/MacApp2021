using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItalyScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject italyGraph;
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

        italyGraph = GameObject.Find("ItalyFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("italyLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("italyLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("italyLabel3").GetComponent<TMP_Text>();
        label3.text = "";


        Renderer[] renderers = italyGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.italy_france[0].ToString() + " GWH";
            label2.text = ChartManager.italy_slovenia[0].ToString() + " GWH";
            label3.text = ChartManager.italy_greece[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.italy_france[0].ToString() + " GWH";
            label2.text = ChartManager2010.italy_slovenia[0].ToString() + " GWH";
            label3.text = ChartManager2010.italy_greece[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.italy_france[0].ToString() + " GWH";
            label2.text = ChartManager2000.italy_slovenia[0].ToString() + " GWH";
            label3.text = ChartManager2000.italy_greece[0].ToString() + " GWH";
        }




        renderer.material = selected;
        Renderer[] renderers = italyGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }


        float[] values = ChartManager.italy;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Italy", selected);
    }

    private void OnMouseExit()
    {
        renderer.material = deselected;
        Renderer[] renderers = italyGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }

        label1.text = "";
        label2.text = "";
        label3.text = "";
    }
}
