using UnityEngine;

namespace CanvasUtil;

// Create a rectTransform
// Set the total size of the content
// all you need to know is, 
// --

// sizeDelta is size of the difference of the anchors multiplied by screen size so
// the sizeDelta width is actually = ((anchorMax.x-anchorMin.x)*screenWidth) + sizeDelta.x
// so assuming a streched horizontally rectTransform on a 1920 screen, this would be
// ((1-0)*1920)+sizeDelta.x
// 1920 + sizeDelta.x
// so if you wanted a 100pixel wide box in the center of the screen you'd do -1820, height as 1920+-1820 = 100
// and if you wanted a fullscreen wide box, its just 0 because 1920+0 = 1920
// the same applies for height

// anchorPosition is basically an offset to the center of the anchors multiplies by screen size so
// a 0.5,0.5 min and 0.5,0.5 max, would put the anchor in the middle of the screen but anchorPosition just offsets that 
// i.e on a 1920x1080 screen
// anchorPosition 100,100 would do (1920*0.5)+100,(1080*0.5)+100, so 1060,640

// ANCHOR MIN / MAX
// --
// 0,0 = bottom left
// 0,1 = top left
// 1,0 = bottom right
// 1,1 = top right
// --


// The only other rects I'd use are
// anchorMin = 0.0, yyy anchorMax = 1.0, yyy (strech horizontally) y = 0.0 is bottom, y = 0.5 is center, y = 1.0 is top
// anchorMin = xxx, 0.0 anchorMax = xxx, 1.0 (strech vertically) x = 0.0 is left, x = 0.5 is center, x = 1.0 is right
// anchorMin = 0.0, 0.0 anchorMax = 1.0, 1.0 (strech to fill)
// --
// technically you can anchor these anywhere on the screen
// you can even use negative values to float something offscreen

// as for the pivot, the pivot determines where the "center" of the rect is which is useful if you want to rotate something by its corner, note that this DOES offset the anchor positions
// i.e. with a 100x100 square, setting the pivot to be 1,1 will put the top right of the square at the anchor position (-50,-50 from its starting position)


/// <summary>
///     Rectangle Helper Class
/// </summary>
public class RectData
{
    /// <summary>
    ///     Describes on of the X,Y Positions of the Element
    /// </summary>
    public Vector2 AnchorMax;

    /// <summary>
    ///     Describes on of the X,Y Positions of the Element
    /// </summary>
    public Vector2 AnchorMin;

    /// <summary>
    /// </summary>
    public Vector2 AnchorPivot;

    /// <summary>
    ///     Relative Offset Postion where Element is anchored as compared to Min / Max
    /// </summary>
    public Vector2 AnchorPosition;

    /// <summary>
    ///     Difference in size of the rectangle as compared to it's parent.
    /// </summary>
    public Vector2 RectSizeDelta;

    /// <inheritdoc />
    /// <summary>
    ///     Describes a Rectangle's relative size, shape, and relative position to it's parent.
    /// </summary>
    /// <param name="sizeDelta">
    ///     sizeDelta is size of the difference of the anchors multiplied by screen size so
    ///     the sizeDelta width is actually = ((anchorMax.x-anchorMin.x)*screenWidth) + sizeDelta.x
    ///     so assuming a streched horizontally rectTransform on a 1920 screen, this would be
    ///     ((1-0)*1920)+sizeDelta.x
    ///     1920 + sizeDelta.x
    ///     so if you wanted a 100pixel wide box in the center of the screen you'd do -1820, height as 1920+-1820 = 100
    ///     and if you wanted a fullscreen wide box, its just 0 because 1920+0 = 1920
    ///     the same applies for height
    /// </param>
    /// <param name="anchorPosition">Relative Offset Postion where Element is anchored as compared to Min / Max</param>
    public RectData(Vector2 sizeDelta, Vector2 anchorPosition)
        : this(sizeDelta, anchorPosition, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f))
    {
    }


    /// <inheritdoc />
    /// <summary>
    ///     Describes a Rectangle's relative size, shape, and relative position to it's parent.
    /// </summary>
    /// <param name="sizeDelta">
    ///     sizeDelta is size of the difference of the anchors multiplied by screen size so
    ///     the sizeDelta width is actually = ((anchorMax.x-anchorMin.x)*screenWidth) + sizeDelta.x
    ///     so assuming a streched horizontally rectTransform on a 1920 screen, this would be
    ///     ((1-0)*1920)+sizeDelta.x
    ///     1920 + sizeDelta.x
    ///     so if you wanted a 100pixel wide box in the center of the screen you'd do -1820, height as 1920+-1820 = 100
    ///     and if you wanted a fullscreen wide box, its just 0 because 1920+0 = 1920
    ///     the same applies for height
    /// </param>
    /// <param name="anchorPosition">Relative Offset Postion where Element is anchored as compared to Min / Max</param>
    /// <param name="min">
    ///     Describes 1 corner of the rectangle
    ///     0,0 = bottom left
    ///     0,1 = top left
    ///     1,0 = bottom right
    ///     1,1 = top right
    /// </param>
    /// <param name="max">
    ///     Describes 1 corner of the rectangle
    ///     0,0 = bottom left
    ///     0,1 = top left
    ///     1,0 = bottom right
    ///     1,1 = top right
    /// </param>
    public RectData(Vector2 sizeDelta, Vector2 anchorPosition, Vector2 min, Vector2 max)
        : this(sizeDelta, anchorPosition, min, max, new Vector2(0.5f, 0.5f))
    {
    }

    /// <summary>
    ///     Describes a Rectangle's relative size, shape, and relative position to it's parent.
    /// </summary>
    /// <param name="sizeDelta">
    ///     sizeDelta is size of the difference of the anchors multiplied by screen size so
    ///     the sizeDelta width is actually = ((anchorMax.x-anchorMin.x)*screenWidth) + sizeDelta.x
    ///     so assuming a streched horizontally rectTransform on a 1920 screen, this would be
    ///     ((1-0)*1920)+sizeDelta.x
    ///     1920 + sizeDelta.x
    ///     so if you wanted a 100pixel wide box in the center of the screen you'd do -1820, height as 1920+-1820 = 100
    ///     and if you wanted a fullscreen wide box, its just 0 because 1920+0 = 1920
    ///     the same applies for height
    /// </param>
    /// <param name="anchorPosition">Relative Offset Postion where Element is anchored as compared to Min / Max</param>
    /// <param name="min">
    ///     Describes 1 corner of the rectangle
    ///     0,0 = bottom left
    ///     0,1 = top left
    ///     1,0 = bottom right
    ///     1,1 = top right
    /// </param>
    /// <param name="max">
    ///     Describes 1 corner of the rectangle
    ///     0,0 = bottom left
    ///     0,1 = top left
    ///     1,0 = bottom right
    ///     1,1 = top right
    /// </param>
    /// <param name="pivot">Controls the location to use to rotate the rectangle if necessary.</param>
    public RectData(Vector2 sizeDelta, Vector2 anchorPosition, Vector2 min, Vector2 max, Vector2 pivot)
    {
        RectSizeDelta = sizeDelta;
        AnchorPosition = anchorPosition;
        AnchorMin = min;
        AnchorMax = max;
        AnchorPivot = pivot;
    }
}
