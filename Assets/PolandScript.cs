using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PolandScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject polandGraph;
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

        polandGraph = GameObject.Find("PolandFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("polandLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("polandLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("polandLabel3").GetComponent<TMP_Text>();
        label3.text = "";
        label4 = GameObject.Find("polandLabel4").GetComponent<TMP_Text>();
        label4.text = "";
        label5 = GameObject.Find("polandLabel5").GetComponent<TMP_Text>();
        label5.text = "";

        Renderer[] renderers = polandGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.poland_sweden[0].ToString() + " GWH";
            label2.text = ChartManager.poland_lithuania[0].ToString() + " GWH";
            label3.text = ChartManager.poland_slovakia[0].ToString() + " GWH";
            label4.text = ChartManager.poland_czechia[0].ToString() + " GWH";
            label5.text = ChartManager.poland_germany[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.poland_sweden[0].ToString() + " GWH";
            label2.text = ChartManager2010.poland_lithuania[0].ToString() + " GWH";
            label3.text = ChartManager2010.poland_slovakia[0].ToString() + " GWH";
            label4.text = ChartManager2010.poland_czechia[0].ToString() + " GWH";
            label5.text = ChartManager2010.poland_germany[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.poland_sweden[0].ToString() + " GWH";
            label2.text = ChartManager2000.poland_lithuania[0].ToString() + " GWH";
            label3.text = ChartManager2000.poland_slovakia[0].ToString() + " GWH";
            label4.text = ChartManager2000.poland_czechia[0].ToString() + " GWH";
            label5.text = ChartManager2000.poland_germany[0].ToString() + " GWH";
        }




        renderer.material = selected;
        Renderer[] renderers = polandGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.poland;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Poland", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";
        label4.text = "";
        label5.text = "";

        renderer.material = deselected;
        Renderer[] renderers = polandGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
