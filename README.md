# CanvasUtil

A utility for making in-game UIs in Hollow Knight: Silksong. This is a direct port of the CanvasUtil
library from the [Hollow Knight Modding API](https://github.com/hk-modding/api/blob/master/Assembly-CSharp/CanvasUtil.cs).

If you are not planning to resize panels, then this should be fairly straightforward to use.
Typically you will start by creating a whole-screen canvas with something like
```
GameObject canvas = CanvasUtil.CanvasUtil.CreateCanvas(RenderMode.ScreenSpaceOverlay, new Vector2(1920, 1080));
```

If you have a canvas or panel GameObject `parent` and you want to add a child panel, then to construct the
RectData to pass into the CreatePanel methods:
* RectSizeDelta should be the size of the child panel.
* AnchorPivot should represent a point on the parent. The coordinates are from (0, 0) to (1, 1), where (0, 0) is the
bottom left corner and (1, 1) is the top right.
* AnchorMin = AnchorMax, and both should represent a point on the child panel. The coordinates are from (0, 0) to (1, 1),
as with the parent.
* AnchorPosition is the offset from the pivot point on the parent to the anchor point on the child.

For example, to put a child in the bottom-right corner of the parent, you can set the anchor pivot, anchor min and anchor max to (1, 0) - this
represents the bottom right corner (max x, min y). The anchor position should be (0, 0) to represent the fact that the anchor pivot
(bottom right corner of parent) and anchor (bottom right corner of child) are the same point.
