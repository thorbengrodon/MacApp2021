using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewChartSkript : MonoBehaviour
{
    //GameObject bar1;
    static public TMP_Text countryName;
    static public TMP_Text bar1Text;
    static public TMP_Text bar2Text;
    static public TMP_Text bar3Text;
    static public TMP_Text bar4Text;
    static public TMP_Text bar5Text;
    static public TMP_Text bar6Text;

    // Start is called before the first frame update
    void Start()
    {

        countryName = GameObject.Find("CountryTextField").GetComponent<TMP_Text>();
        bar1Text = GameObject.Find("Bar1Text").GetComponent<TMP_Text>();
        bar2Text = GameObject.Find("Bar2Text").GetComponent<TMP_Text>();
        bar3Text = GameObject.Find("Bar3Text").GetComponent<TMP_Text>();
        bar4Text = GameObject.Find("Bar4Text").GetComponent<TMP_Text>();
        bar5Text = GameObject.Find("Bar5Text").GetComponent<TMP_Text>();
        bar6Text = GameObject.Find("Bar6Text").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void updateChart(float value1, float value2, float value3, float value4, float value5, float value6, string country, Material testMaterial) {
        float step = 5.0f * Time.deltaTime;
        float x = 1.0f;
        float z = 1.0f;

        GameObject bar1 = GameObject.Find("Bar1Parent");
        GameObject bar2 = GameObject.Find("Bar2Parent");
        GameObject bar3 = GameObject.Find("Bar3Parent");
        GameObject bar4 = GameObject.Find("Bar4Parent");
        GameObject bar5 = GameObject.Find("Bar5Parent");
        GameObject bar6 = GameObject.Find("Bar6Parent");

        Vector3 change1 = new Vector3(x, value1, z);
        Vector3 change2 = new Vector3(x, value2, z);
        Vector3 change3 = new Vector3(x, value3, z);
        Vector3 change4 = new Vector3(x, value4, z);
        Vector3 change5 = new Vector3(x, value5, z);
        Vector3 change6 = new Vector3(x, value6, z);

        bar1.transform.localScale = change1;
        bar2.transform.localScale = change2;
        bar3.transform.localScale = change3;
        bar4.transform.localScale = change4;
        bar5.transform.localScale = change5;
        bar6.transform.localScale = change6;

        countryName.text = country;
        bar1Text.text = (value1*100).ToString();
        bar2Text.text = (value2 * 100).ToString() + "%";
        bar3Text.text = (value3 * 100).ToString() + "%";
        bar4Text.text = (value4 * 100).ToString() + "%";
        bar5Text.text = (value5 * 100).ToString() + "%";
        bar6Text.text = (value6 * 100).ToString() + "%";
    }

    
}
