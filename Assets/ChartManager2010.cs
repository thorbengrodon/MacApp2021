using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager2010 : MonoBehaviour
{
    static public float chartBarHeight;
    static public Material testPink = Resources.Load<Material>("MyMaterials/TestPink");
    static public bool showAll = false;


    // 1. Oil | 2. Gas | 3. Renewable | 4. Nuclear | 5. Solid fossil fules | 6. Other
    static public float[] uk = { 0, 0, 0, 0, 0, 0 }; // KeineEU
    static public float[] spain = { 45.7f, 23.4f, 16.3f, 11.7f, 2.9f, 0.0f }; //check 
    static public float[] portugal = { 44.2f, 22.4f, 29.9f, 0.0f, 1.7f, 1.8f }; // check 
    static public float[] france = { 22.8f, 15.2f, 12.7f, 40.7f, 4.2f, -1.6f }; // check
    static public float[] germany = { 33.4f, 26.3f, 15.6f, 6.0f, 19.3f, -0.6f }; // check
    static public float[] italy = { 34.3f, 40.0f, 19.1f, 0.0f, 4.3f, 2.3f }; // check
    static public float[] ireland = { 47.8f, 30.2f, 11.3f, 0.0f, 9.7f, 1.0f }; // liefert nur nach UK
    static public float[] bulgaria = { 24.0f, 14.7f, 15.0f, 22.2f, 27.7f, -3.6f }; // check
    static public float[] romania = { 30.7f, 29.0f, 18.6f, 8.3f, 12.8f, 0.6f }; // check
    static public float[] slovakia = { 21.0f, 25.6f, 13.1f, 22.8f, 17.2f }; // check
    static public float[] greece = { 51.5f, 23.4f, 16.5f, 0.0f, 7.4f, 1.2f }; // check
    static public float[] hungary = { 29.6f, 33.9f, 11.8f, 14.7f, 5.9f, 4.1f }; // check
    static public float[] serbia = { 0, 0, 0, 0, 0, 0 }; // KeineEU
    static public float[] sweden = { 24.0f, 2.0f, 48.2f, 24.7f, 5.4f, -4.3f }; // check
    static public float[] finland = { 22.2f, 6.3f, 40.3f, 16.5f, 9.8f, 4.9f }; // check
    static public float[] estonia = { 3.8f, 8.5f, 26.9f, 0.0f, 56.2f, 4.6f }; // check
    static public float[] latvia = { 35.6f, 20.1f, 39.8f, 0.0f, 1.4f, 3.1f }; // check
    static public float[] lithuania = { 38.0f, 23.1f, 23.0f, 0.0f, 3.4f, 12.5f }; // check
    static public float[] belarus = { 0, 0, 0, 0, 0, 0 }; // KeineEU
    static public float[] croatia = { 34.1f, 27.9f, 28.8f, 0.0f, 5.3f, 3.9f }; // check
    static public float[] slovenia = { 34.4f, 11.7f, 19.0f, 20.4f, 14.9f, -0.4f }; // check
    static public float[] poland = { 28.8f, 16.6f, 11.9f, 0.0f, 42.7f, 0.0f }; // check
    static public float[] denmark = { 37.2f, 11.1f, 40.4f, 0.0f, 8.9f, 2.4f }; // check
    static public float[] belgium_luxembourg = { 44.9f, 23.7f, 8.0f, 19.0f, 5.1f, -0.7f }; //check
    static public float[] austria = { 34.7f, 22.6f, 31.3f, 0.0f, 9.4f, 2.0f }; // check
    static public float[] czechrepublic = { 22.1f, 18.2f, 12.9f, 17.9f, 31.1f, -2.2f }; // check
    static public float[] netherlands = { 46.2f, 35.3f, 9.5f, 1.0f, 7.7f, 0.3f }; // check


    static public float[] spain_portugal = { 5823f };
    static public float[] spain_france = { 3514f };

    static public float[] portugal_spain = { 3191, 42 };

    static public float[] france_italy = { 11656f };
    static public float[] france_spain = { 2000f };
    static public float[] france_germay = { 15132f };
    static public float[] france_belgium = { 3182f }; // Wegen Belgien

    static public float[] germany_austria = { 14816 };
    static public float[] germany_netherland = { 8796 };
    static public float[] germany_poland = { 5331 };
    static public float[] germany_czechia = { 565 };
    static public float[] germany_france = { 793 };

    static public float[] italy_france = { 1140f };
    static public float[] italy_greece = { 67f };
    static public float[] italy_slovenia = { 124f };
    static public float[] italy_austria = { 3f };

    static public float[] ireland_uk = { 289f };

    static public float[] bulgaria_serbia = { 1793f };
    static public float[] bulgaria_romania = { 676f };
    static public float[] bulgaria_greece = { 3454f };

    static public float[] romania_hungary = { 535 };
    static public float[] romania_bulgaria = { 148 };

    static public float[] slovakia_hungary = { 4935 };
    static public float[] slovakia_czechia = { 365 };
    static public float[] slovakia_poland = { 82 };

    static public float[] greece_italy = { 2312 };
    static public float[] greece_bulgaria = { 2 };

    static public float[] hungary_croatia = { 3044 };
    static public float[] hungary_romania = { 146 };
    static public float[] hungary_austria = { 641 };
    static public float[] hungary_serbia = { 392 };
    static public float[] hungary_slovakia = { 56 };

    static public float[] sweden_finland = { 1911 };
    static public float[] sweden_denmark = { 2465 };
    static public float[] sweden_lithuania = { 2556 }; // Lativa?
    static public float[] sweden_poland = { 760 };
    static public float[] sweden_norway = { 36706 };
    static public float[] sweden_germany = { 1011 };

    static public float[] finland_estonia = { 246 };
    static public float[] finland_norway = { 156 };
    static public float[] finland_sweden = { 4816 };

    static public float[] estonia_lativa = { 2695f };
    static public float[] estonia_finland = { 1659 };

    static public float[] lativa_lithuania = { 3053f };
    static public float[] lativa_estonia = { 38f };

    static public float[] lithuania_poland = { 14 };
    static public float[] lithuania_lativa = { 235f };
    static public float[] lithuania_sweden = { 122 };

    static public float[] croatia_slovenia = { 6434f };
    static public float[] croatia_hungary = { 92f };
    static public float[] croatia_serbia = { 275.6f };

    static public float[] slovenia_italy = { 7516f };
    static public float[] slovenia_croatia = { 2646f };
    static public float[] slovenia_austria = { 583f };

    static public float[] poland_czechia = { 5504f };
    static public float[] poland_slovakia = { 1499f };
    static public float[] poland_lithuania = { 65 };
    static public float[] poland_germany = { 167 };
    static public float[] poland_sweden = { 494f };

    static public float[] denmark_germany = { 2700f };
    static public float[] denmark_netherland = { 637 };
    static public float[] denmark_sweden = { 4985f };
    static public float[] denmark_norway = { 4049f };


    static public float[] belgiumLuxembourg_france = { 5409f };
    static public float[] belgiumLuxembourg_netherlands = { 5313f };
    static public float[] belgiumLuxembourg_germany = { 123 };

    static public float[] austria_germany = { 4693f };
    static public float[] austria_slovenia = { 2386f };
    static public float[] austria_hungary = {1013f};
    static public float[] austria_italy = { 1326 };
    static public float[] austria_czechia = { 251 };

    static public float[] czechrepublic_austria = { 6292f };
    static public float[] czechrepublic_slovakia = { 5140f };
    static public float[] czechrepublic_germany = { 8834f };
    static public float[] czechrepublic_poland = { 525 };

    static public float[] netherlands_germany = { 3071f };
    static public float[] netherlands_belgium = { 7390f };
    static public float[] netherlands_denmark = { 671f };
    



    // static plublic float spainLands = {};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
