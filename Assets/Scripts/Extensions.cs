using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;
using System.Text;

namespace InfinityTetris
{
    public static class Extensions
    {
        #region Arrays

        public static T RandomElement<T>(this T[] arr)
        {
            return arr[Random.Range(0, arr.Length)];
        }

        public static string StringifyElements<T>(this T[] arr)
        {
            StringBuilder result = new();
            foreach(T element in arr)
            {
                result.Append(element + " ");
            }

            return result.ToString();
        }

        #endregion

        #region Lists

        public static T RandomElement<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                T temp = list[i];
                int randomIndex = Random.Range(i, list.Count);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            return list;
        }

        #endregion

        #region floats

        public static void Clamp(this ref float val, float min, float max)
        {
            val.ClampLower(min);
            val.ClampUpper(max);
        }

        public static void ClampLower(this ref float val, float min)
        {
            if (val < min)
            {
                val = min;
            }
        }

        public static void ClampUpper(this ref float val, float max)
        {
            if (val > max)
            {
                val = max;
            }
        }

        #endregion

        #region ints

        public static void Clamp(this ref int val, int min, int max)
        {
            val.ClampLower(min);
            val.ClampUpper(max);
        }

        public static void ClampLower(this ref int val, int min)
        {
            if (val < min)
            {
                val = min;
            }
        }

        public static void ClampUpper(this ref int val, int max)
        {
            if (val > max)
            {
                val = max;
            }
        }

        #endregion

        #region Enums
        // This allows you to add a "description" annotation
        // over enums and to retreive it by calling this method
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
        #endregion

        #region Transform
        public static void DestroyAllChildren(this Transform value)
        {
            foreach (Transform child in value)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static void DestroyAllChildrenImmediate(this Transform value)
        {
            for(int i=value.childCount-1; i >=0; i--)
            {
                GameObject.DestroyImmediate(value.GetChild(i).gameObject);
            }
        }
        #endregion

        #region Image
        public static void SetAlpha(this Image image, float alpha)
        {
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;
        }
        #endregion

        #region ScrollRect
        public static void ScrollToTop(this ScrollRect scrollRect)
        {
            Canvas.ForceUpdateCanvases();
            scrollRect.StartCoroutine(ScrollTop(scrollRect));
        }
        private static IEnumerator ScrollTop(ScrollRect scrollRect)
        {
            yield return new WaitForEndOfFrame();
            scrollRect.normalizedPosition = new Vector2(0, 1);
        }
        public static void ScrollToBottom(this ScrollRect scrollRect)
        {
            Canvas.ForceUpdateCanvases();
            scrollRect.StartCoroutine(ScrollBottom(scrollRect));
        }
        private static IEnumerator ScrollBottom(ScrollRect scrollRect)
        {
            yield return new WaitForEndOfFrame();
            scrollRect.normalizedPosition = new Vector2(0, 0);
        }
        #endregion
    }
}
