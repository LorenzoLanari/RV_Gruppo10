using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Componente : MonoBehaviour
{
    public Text titleText1;
    public Text descriptionText1;
    public Text titleText2;
    public Text descriptionText2;

    public string title1;
    [TextArea(3, 15)]
    public string description1;

    public string title2;
    [TextArea(3, 15)]
    public string description2;

    // Start is called before the first frame update
    void Start()
    {
        titleText1.text = title1;
        descriptionText1.text = description1;

        titleText2.text = title2;
        descriptionText2.text = description2;
    }

   
}
