using System;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasUtil;

/// <summary>
/// Class with utilities for creating a text panel to show debug info.
/// 
/// This is useful for debugging aspects of your mod,
/// and is not expected to be used in released mods.
/// </summary>
public class DebugPanel : MonoBehaviour
{
    private const int FONT_SIZE = 18;

    /// <summary>
    /// Create a panel showing a single string that can update each frame.
    /// </summary>
    /// <param name="generator">Function to generate the text that will be shown each frame.
    /// The text can spread over multiple lines.
    /// 
    /// If this is null, the text will not automatically update and should be manually
    /// updated by calling <see cref="SetText"/>.
    /// </param>
    public static DebugPanel Create(Func<string>? generator = null)
    {
        GameObject canvas = CanvasUtil.CreateCanvas(RenderMode.ScreenSpaceOverlay, new Vector2(1920, 1080));
        canvas.name = $"{nameof(DebugPanel)} Canvas";
        
        CanvasGroup cg = canvas.GetComponent<CanvasGroup>();
        cg.interactable = false;
        cg.blocksRaycasts = false;
        
        DontDestroyOnLoad(canvas);

        GameObject basePanel = CanvasUtil.CreateBasePanel(
            canvas,
                new RectData(
                new(550, 700),
                new(100, -300),
                new(0, 1),
                new(0, 1),
                new(0, 1)
                )
            );
        Image img = basePanel.AddComponent<Image>();
        img.color = new Color(0, 0, 0, 0.25f);

        GameObject textPanel = CanvasUtil.CreateTextPanel(
            basePanel, string.Empty, fontSize: FONT_SIZE, textAnchor: TextAnchor.UpperLeft,
            new RectData(new(500, 650), new(25, -25)),
            DefaultFont
            );

        if (generator is not null)
        {
            TextUpdate tu = textPanel.AddComponent<TextUpdate>();
            tu.Generator = generator;
        }

        DebugPanel debugPanel = canvas.AddComponent<DebugPanel>();
        debugPanel.Text = textPanel.GetComponent<Text>();
        debugPanel.basePanel = basePanel;

        return debugPanel;
    }

    /// <summary>
    /// Set the text that is being displayed.
    /// </summary>
    /// <param name="s">The text that will be shown. This can spread over multiple lines.</param>
    public void SetText(string s)
    {
        Text.text = s;
    }

    /// <summary>
    /// The <see cref="UnityEngine.UI.Text"/> object that is displaying the text.
    /// </summary>
    public Text Text { get; private set; } = null!;

    /// <summary>
    /// Toggle whether the panel is visible.
    /// </summary>
    public void SetPanelVisible(bool visible)
    {
        basePanel?.SetActive(visible);
    }

    private GameObject basePanel = null!;

    private static readonly string[] OSFonts =
    {
        "Consolas",
        "Menlo",
        "Courier New",
        "DejaVu Mono"
    };
    private static Font? _font;

    /// <summary>
    /// The default font used for the debug panel.
    /// </summary>
    public static Font DefaultFont
    {
        get
        {
            if (_font == null)
            {
                _font = Font.CreateDynamicFontFromOSFont(OSFonts, FONT_SIZE);
            }
            return _font;
        }
    }

    [RequireComponent(typeof(Text))]
    private class TextUpdate : MonoBehaviour
    {
        public Func<string>? Generator { get; set; }
        private Text _text;

        void Awake() => _text = GetComponent<Text>();

        void Update() => _text.text = Generator?.Invoke() ?? string.Empty;
    }
}
