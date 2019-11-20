using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySettins : MonoBehaviour
{
    public void SetQuality(int qualitynumber)
    {
        QualitySettings.SetQualityLevel(qualitynumber, true);
    }
}
