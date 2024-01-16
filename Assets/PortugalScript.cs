using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PortugalScript : MonoBehaviour
{
    Renderer renderer;
    Material selected;
    Material deselected;

    GameObject portugalGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");

        portugalGraph = GameObject.Find("PortugalFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        renderer.material = deselected;

        label1 = GameObject.Find("portugalLabel1").GetComponent<TMP_Text>();
        label1.text = "";

        Renderer[] renderers = portugalGraph.GetComponentsInChildren<Renderer>();
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
            label1.text = ChartManager.portugal_spain[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.portugal_spain[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.portugal_spain[0].ToString() + " GWH";
        }




        //label1.text = ChartManager.portugal_spain[0].ToString() + " GWH";
        renderer.material = selected;
        //portugalGraph.GetComponent<MeshRenderer>().material = selectedGraph;

        Renderer[] renderers = portugalGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

    }

    private void OnMouseExit()
    {
        label1.text = "";

        renderer.material = deselected;
        //portugalGraph.GetComponent<MeshRenderer>().material = deseletedGraph;


        Renderer[] renderers = portugalGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
