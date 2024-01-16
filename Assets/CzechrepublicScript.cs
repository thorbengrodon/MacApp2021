using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CzechrepublicScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject tschechenGraph;
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

        tschechenGraph = GameObject.Find("TschechenFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("tschechenLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("tschechenLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("tschechenLabel3").GetComponent<TMP_Text>();
        label3.text = "";
        label4 = GameObject.Find("tschechenLabel4").GetComponent<TMP_Text>();
        label4.text = "";

        Renderer[] renderers = tschechenGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.czechrepublic_poland[0].ToString() + " GWH";
            label2.text = ChartManager.czechrepublic_slovakia[0].ToString() + " GWH";
            label3.text = ChartManager.czechrepublic_austria[0].ToString() + " GWH";
            label4.text = ChartManager.czechrepublic_germany[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.czechrepublic_poland[0].ToString() + " GWH";
            label2.text = ChartManager2010.czechrepublic_slovakia[0].ToString() + " GWH";
            label3.text = ChartManager2010.czechrepublic_austria[0].ToString() + " GWH";
            label4.text = ChartManager2010.czechrepublic_germany[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.czechrepublic_poland[0].ToString() + " GWH";
            label2.text = ChartManager2000.czechrepublic_slovakia[0].ToString() + " GWH";
            label3.text = ChartManager2000.czechrepublic_austria[0].ToString() + " GWH";
            label4.text = ChartManager2000.czechrepublic_germany[0].ToString() + " GWH";
        }





        renderer.material = selected;
        Renderer[] renderers = tschechenGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }


        float[] values = ChartManager.czechrepublic;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Czechrepublic", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";
        label4.text = "";

        renderer.material = deselected;
        Renderer[] renderers = tschechenGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
