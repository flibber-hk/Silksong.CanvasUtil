using BepInEx;

namespace CanvasUtil;

[BepInAutoPlugin(id: "io.github.flibber-hk.canvasutil")]
public partial class CanvasUtilPlugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }
}
