using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SloveniaScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject sloveniaGraph;
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

        sloveniaGraph = GameObject.Find("SloveniaFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("sloveniaLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("sloveniaLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("sloveniaLabel3").GetComponent<TMP_Text>();
        label3.text = "";

        Renderer[] renderers = sloveniaGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.slovenia_austria[0].ToString() + " GWH";
            label2.text = ChartManager.slovenia_croatia[0].ToString() + " GWH";
            label3.text = ChartManager.slovenia_italy[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.slovenia_austria[0].ToString() + " GWH";
            label2.text = ChartManager2010.slovenia_croatia[0].ToString() + " GWH";
            label3.text = ChartManager2010.slovenia_italy[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.slovenia_austria[0].ToString() + " GWH";
            label2.text = ChartManager2000.slovenia_croatia[0].ToString() + " GWH";
            label3.text = ChartManager2000.slovenia_italy[0].ToString() + " GWH";
        }




        renderer.material = selected;
        Renderer[] renderers = sloveniaGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.slovenia;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Slovenia", selected);
    }

    private void OnMouseExit()
    {
        label1.text = "";
        label2.text = "";
        label3.text = "";

        renderer.material = deselected;
        Renderer[] renderers = sloveniaGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
