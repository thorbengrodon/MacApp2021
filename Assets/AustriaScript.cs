using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AustriaScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject austriaGraph;
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

        austriaGraph = GameObject.Find("AustriaFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("austriaLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("austriaLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("austriaLabel3").GetComponent<TMP_Text>();
        label3.text = "";
        label4 = GameObject.Find("austriaLabel4").GetComponent<TMP_Text>();
        label4.text = "";
        label5 = GameObject.Find("austriaLabel5").GetComponent<TMP_Text>();
        label5.text = "";

        Renderer[] renderers = austriaGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.austria_czechia[0].ToString() + " GWH";
            label2.text = ChartManager.austria_hungary[0].ToString() + " GWH";
            label3.text = ChartManager.austria_slovenia[0].ToString() + " GWH";
            label4.text = ChartManager.austria_italy[0].ToString() + " GWH";
            label5.text = ChartManager.austria_germany[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.austria_czechia[0].ToString() + " GWH";
            label2.text = ChartManager2000.austria_hungary[0].ToString() + " GWH";
            label3.text = ChartManager2000.austria_slovenia[0].ToString() + " GWH";
            label4.text = ChartManager2000.austria_italy[0].ToString() + " GWH";
            label5.text = ChartManager2000.austria_germany[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.austria_czechia[0].ToString() + " GWH";
            label2.text = ChartManager2010.austria_hungary[0].ToString() + " GWH";
            label3.text = ChartManager2010.austria_slovenia[0].ToString() + " GWH";
            label4.text = ChartManager2010.austria_italy[0].ToString() + " GWH";
            label5.text = ChartManager2010.austria_germany[0].ToString() + " GWH";
        }




        renderer.material = selected;
        Renderer[] renderers = austriaGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.austria;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Austria", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";
        label4.text = "";
        label5.text = "";

        renderer.material = deselected;
        Renderer[] renderers = austriaGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
