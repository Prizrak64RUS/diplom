using UnityEngine;

namespace Assets.myScript.button
{
    class ButtonClass
    {
        public static void exchange(RectTransform x1, RectTransform x2)
        {
            var trans = x1.localPosition;
            x1.localPosition = x2.localPosition;
            x2.localPosition = trans;
        }
    }
}
