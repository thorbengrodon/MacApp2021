using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager : MonoBehaviour
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


    static public float[] spain_portugal = { 9543.5f };
    static public float[] spain_france = { 6280.8f };

    static public float[] portugal_spain = { 4791.1f, 42 };

    static public float[] france_italy = { 15118.9f };
    static public float[] france_spain = { 11917f };
    static public float[] france_germay = { 9753.1f };
    static public float[] france_belgium = { 5127 }; // Wegen Belgien

    static public float[] germany_austria = { 13347f };
    static public float[] germany_netherland = { 9085 };
    static public float[] germany_poland = { 8734 };
    static public float[] germany_czechia = { 6221 };
    static public float[] germany_france = { 4196 };

    static public float[] italy_france = { 1184 };
    static public float[] italy_greece = { 517 };
    static public float[] italy_slovenia = { 73.9f }; // nicht auf karte
    static public float[] italy_austria = { 12 };

    static public float[] ireland_uk = { 863.1f };

    static public float[] bulgaria_serbia = { 2708 };
    static public float[] bulgaria_romania = { 2330 };
    static public float[] bulgaria_greece = { 1971 };

    static public float[] romania_hungary = { 2462 };
    static public float[] romania_bulgaria = { 1664 };

    static public float[] slovakia_hungary = { 10722 };
    static public float[] slovakia_czechia = { 327 };
    static public float[] slovakia_poland = { 78 };

    static public float[] greece_italy = { 1857 };
    static public float[] greece_bulgaria = { 64 };

    static public float[] hungary_croatia = { 3317 };
    static public float[] hungary_romania = { 1628 };
    static public float[] hungary_austria = { 715 };
    static public float[] hungary_serbia = { 562 };
    static public float[] hungary_slovakia = { 110 };

    static public float[] sweden_finland = { 15013 };
    static public float[] sweden_denmark = { 6666 };
    static public float[] sweden_lithuania = { 3445 };
    static public float[] sweden_poland = { 3431 };
    static public float[] sweden_norway = { 3086 };
    static public float[] sweden_germany = { 2268 };

    static public float[] finland_estonia = { 6691 };
    static public float[] finland_norway = { 19 };
    static public float[] finland_sweden = { 14 };

    static public float[] estonia_lativa = { 4415 };
    static public float[] estonia_finland = { 288 };

    static public float[] lativa_lithuania = { 2682 };
    static public float[] lativa_estonia = { 156 };

    static public float[] lithuania_poland = { 1684 };
    static public float[] lithuania_lativa = { 1032 };
    static public float[] lithuania_sweden = { 253 };

    static public float[] croatia_slovenia = { 4328 };
    static public float[] croatia_hungary = { 774 };
    static public float[] croatia_serbia = { 275 };

    static public float[] slovenia_italy = { 5449 };
    static public float[] slovenia_croatia = { 2498 };
    static public float[] slovenia_austria = { 709 };

    static public float[] poland_czechia = { 8353 };
    static public float[] poland_slovakia = { 4626 };
    static public float[] poland_lithuania = { 210 };
    static public float[] poland_germany = { 326 };
    static public float[] poland_sweden = { 210 };

    static public float[] denmark_germany = { 8333 };
    static public float[] denmark_netherland = { 3091 };
    static public float[] denmark_sweden = { 2105 };
    static public float[] denmark_norway = { 1720 };


    static public float[] belgiumLuxembourg_france = { 7733 };
    static public float[] belgiumLuxembourg_netherlands = { 5217 };
    static public float[] belgiumLuxembourg_germany = { 1811 };

    static public float[] austria_germany = { 6081 };
    static public float[] austria_slovenia = { 3985 };
    static public float[] austria_hungary = { 3255 };
    static public float[] austria_italy = { 1258 };
    static public float[] austria_czechia = { 197 };

    static public float[] czechrepublic_austria = { 10917 };
    static public float[] czechrepublic_slovakia = { 8884 };
    static public float[] czechrepublic_germany = { 6083 };
    static public float[] czechrepublic_poland = { 343 };

    static public float[] netherlands_germany = { 7640 };
    static public float[] netherlands_belgium = { 7320 };
    static public float[] netherlands_denmark = { 875 };
    



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
