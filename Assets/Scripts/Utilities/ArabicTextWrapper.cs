using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public enum TextType { Canvas, TextMesh }
public class ArabicTextWrapper : MonoBehaviour {

    public TextType textType;

	// Use this for initialization
	void Start () {
        SetText();
	}



    void SetText()
    {
        switch (textType)
        {
            case TextType.Canvas:
                Text textComp = GetComponent<Text>();
                if (textComp != null)
                    textComp.text = ArabicFixer.Fix(textComp.text, false, false);
                break;
            case TextType.TextMesh:
                TextMesh textMeshComp = GetComponent<TextMesh>();
                if (textMeshComp != null)
                    textMeshComp.text = ArabicFixer.Fix(textMeshComp.text, false, false);
                break;
            default:
                break;
        }
    }
}
