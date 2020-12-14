using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textcolorclicked : MonoBehaviour
{
    public Text t;
    // Start is called before the first frame update
    

    public void ChangeColor()
    {
        t.color = Color.yellow;
    }


}
