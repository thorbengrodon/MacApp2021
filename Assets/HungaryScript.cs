using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HungaryScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject hungaryGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;
    TMP_Text label2;
    TMP_Text label3;
    TMP_Text label4;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();

        hungaryGraph = GameObject.Find("HungaryFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("hungaryLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("hungaryLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("hungaryLabel3").GetComponent<TMP_Text>();
        label3.text = "";
        label4 = GameObject.Find("hungaryLabel4").GetComponent<TMP_Text>();
        label4.text = "";

        Renderer[] renderers = hungaryGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.hungary_slovakia[0].ToString() + " GWH";
            label2.text = ChartManager.hungary_romania[0].ToString() + " GWH";
            label3.text = ChartManager.hungary_croatia[0].ToString() + " GWH";
            label4.text = ChartManager.hungary_austria[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.hungary_slovakia[0].ToString() + " GWH";
            label2.text = ChartManager2010.hungary_romania[0].ToString() + " GWH";
            label3.text = ChartManager2010.hungary_croatia[0].ToString() + " GWH";
            label4.text = ChartManager2010.hungary_austria[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.hungary_slovakia[0].ToString() + " GWH";
            label2.text = ChartManager2000.hungary_romania[0].ToString() + " GWH";
            label3.text = ChartManager2000.hungary_croatia[0].ToString() + " GWH";
            label4.text = ChartManager2000.hungary_austria[0].ToString() + " GWH";
        }



        renderer.material = selected;
        Renderer[] renderers = hungaryGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.hungary;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Hungary", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";
        label4.text = "";

        renderer.material = deselected;
        Renderer[] renderers = hungaryGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
