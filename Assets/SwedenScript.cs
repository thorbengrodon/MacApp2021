using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SwedenScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject swedenGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;
    TMP_Text label2;
    TMP_Text label3;
    TMP_Text label4;
    TMP_Text label5;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();

        swedenGraph = GameObject.Find("SwedenFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("SwedenLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("SwedenLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("SwedenLabel3").GetComponent<TMP_Text>();
        label3.text = "";
        label4 = GameObject.Find("SwedenLabel4").GetComponent<TMP_Text>();
        label4.text = "";
        label5 = GameObject.Find("SwedenLabel5").GetComponent<TMP_Text>();
        label5.text = "";

        Renderer[] renderers = swedenGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.sweden_finland[0].ToString() + " GWH";
            label2.text = ChartManager.sweden_lithuania[0].ToString() + " GWH";
            label3.text = ChartManager.sweden_poland[0].ToString() + " GWH";
            label4.text = ChartManager.sweden_germany[0].ToString() + " GWH";
            label5.text = ChartManager.sweden_denmark[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.sweden_finland[0].ToString() + " GWH";
            label2.text = ChartManager2010.sweden_lithuania[0].ToString() + " GWH";
            label3.text = ChartManager2010.sweden_poland[0].ToString() + " GWH";
            label4.text = ChartManager2010.sweden_germany[0].ToString() + " GWH";
            label5.text = ChartManager2010.sweden_denmark[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.sweden_finland[0].ToString() + " GWH";
            label2.text = ChartManager2000.sweden_lithuania[0].ToString() + " GWH";
            label3.text = ChartManager2000.sweden_poland[0].ToString() + " GWH";
            label4.text = ChartManager2000.sweden_germany[0].ToString() + " GWH";
            label5.text = ChartManager2000.sweden_denmark[0].ToString() + " GWH";
        }





        renderer.material = selected;
        Renderer[] renderers = swedenGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.sweden;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Sweden", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";
        label4.text = "";
        label5.text = "";

        renderer.material = deselected;
        Renderer[] renderers = swedenGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
