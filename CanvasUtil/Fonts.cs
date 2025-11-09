using System.Collections.Generic;
using UnityEngine;

namespace CanvasUtil;

/// <summary>
/// Utility for accessing fonts.
/// </summary>
public static class Fonts
{
    private static Font? _trajanBold;
    private static Font? _trajanNormal;

    /// <summary>
    /// Access to the TrajanBold Font
    /// </summary>
    public static Font? TrajanBold
    {
        get
        {
            if (!_trajanBold) CreateFonts();

            return _trajanBold;
        }

    }

    /// <summary>
    /// Access to the TrajanNormal Font
    /// </summary>
    public static Font? TrajanNormal
    {
        get
        {
            if (!_trajanNormal) CreateFonts();

            return _trajanNormal;
        }
    }

    private static readonly Dictionary<string, Font> fonts = new();

    /// <summary>
    /// Fetches the Trajan fonts to be cached and used.
    /// </summary>
    private static void CreateFonts()
    {
        foreach (Font f in Resources.FindObjectsOfTypeAll<Font>())
        {
            if (f != null && f.name == "TrajanPro-Bold")
            {
                _trajanBold = f;
            }

            if (f != null && f.name == "TrajanPro-Regular")
            {
                _trajanNormal = f;
            }
        }
    }


    /// <summary>
    /// Fetches the cached font if it exists.
    /// </summary>
    /// <param name="fontName"></param>
    /// <returns>Font if found, null if not.</returns>
    public static Font? GetFont(string fontName)
    {
        if (fonts.ContainsKey(fontName))
        {
            return fonts[fontName];
        }

        foreach (Font f in Resources.FindObjectsOfTypeAll<Font>())
        {
            if (f != null && f.name == fontName)
            {
                fonts.Add(fontName, f);
                break;
            }
        }

        return fonts.TryGetValue(fontName, out Font? value) ? value : null;
    }
}
