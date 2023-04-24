using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public static class UIHelper
    {
        ///// <summary>
        ///// 以指定父节点的第一个节点为模版生成子节点
        ///// </summary>
        ///// <param name="parent"></param>
        ///// <param name="count"></param>
        //public static void GenerateByTempalte(Transform parent, int count)
        //{
        //    if (parent == null)
        //    {
        //        Log.Error("父节点是空的!");
        //        return;
        //    }

        //    var childCount = parent.childCount;
        //    //if (childCount > 1)
        //    //{
        //    //    Log.Error("子节点大于一个,为了避免有不同的子节点，先认为这个情况是错误的");
        //    //    return;
        //    //}

        //    // 需要生成
        //    if (count > childCount)
        //    {
        //        var template = parent.GetChild(0);
        //        for (int i = childCount; i < count; ++i)
        //            GameObject.Instantiate(template, parent);
        //    }
        //    // 不需要生成
        //    else
        //    {
        //        for (int i = count; i < childCount; ++i)
        //        {
        //            var child = parent.GetChild(i);
        //            child.gameObject.SetActive(false);
        //        }
        //    }
        //}
    }
}
