using BepInEx;

namespace CanvasUtil;

[BepInAutoPlugin(id: "io.github.flibber-hk.canvasutil")]
#pragma warning disable CS1591  // Missing XML comment for publicly visible type or member
public partial class CanvasUtilPlugin : BaseUnityPlugin
#pragma warning restore CS1591  // Missing XML comment for publicly visible type or member
{
    private void Awake()
    {
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }
}
