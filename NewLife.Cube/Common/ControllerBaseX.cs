﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NewLife.Cube
{
    /// <summary>控制器基类</summary>
    public class ControllerBaseX : Controller
    {
        #region 权限菜单
        /// <summary>获取可用于生成权限菜单的Action集合</summary>
        /// <returns></returns>
        protected virtual MethodInfo[] GetActions()
        {
            var list = new List<MethodInfo>();

            var type = this.GetType();
            // 添加该类型下的所有Action
            foreach (var method in type.GetMethods())
            {
                if (method.IsStatic || !method.IsPublic) continue;

                if (!typeof(ActionResult).IsAssignableFrom(method.ReturnType)) continue;

                if (method.GetCustomAttribute<HttpPostAttribute>() != null) continue;

                list.Add(method);
            }

            return list.ToArray();
        }
        #endregion
    }
}