using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class cambioIdioma : MonoBehaviour
{
    public void CambiarIdioma(int indiceIdioma){
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indiceIdioma];
    }
}
