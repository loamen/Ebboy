using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Linq.Expressions;
using Ebboy.Core.Extensions;

namespace Ebboy.Web.Framework.Mvc
{
    /// <summary>
    /// 级联下拉列表扩展
    /// </summary>
    public static class MutiSelectExtensions
    {
        /// <summary>
        /// 级联下拉列表扩展
        /// </summary>
        /// <param name="helper">HTML辅助类</param>
        /// <param name="options">参数设置</param>
        /// <param name="tree">树列表</param>
        /// <returns>HTML字符串</returns>
        /// 创 建 者：Loamen.com
        public static MvcHtmlString MutiSelect(this HtmlHelper helper, MutiOptions options, IList<Tree> tree)
        {
            //HTML字符串
            StringBuilder selectString = new StringBuilder();
            //选中值
            string selectedValue = null;
            //设置默认值
            if (options.EmptyText == null)
            {
                options.EmptyText = "全部";
                options.EmptyValue = "";
            }
            //创建列表
            CreateSelect(selectString, options, tree, ref selectedValue, 1);
            //如果包含选中值，按照参数生成隐藏域
            if (!string.IsNullOrWhiteSpace(options.SelectIdName))
            {
                TagBuilder hidden = new TagBuilder("input");
                hidden.Attributes["name"] = options.SelectIdName ?? "selectedvalue";
                hidden.Attributes["id"] = options.SelectIdName ?? "selectedvalue";
                hidden.Attributes["type"] = "hidden";
                hidden.Attributes["value"] = selectedValue ?? "";
                ModelMetadata metadata = ModelMetadata.FromStringExpression(options.SelectIdName, helper.ViewData);
                if (!string.IsNullOrWhiteSpace(metadata.PropertyName))
                {
                    string fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(options.SelectIdName);
                    ModelState modelState;
                    if (helper.ViewData.ModelState.TryGetValue(fullName, out modelState))
                    {
                        if (modelState.Errors.Count > 0)
                        {
                            hidden.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                        }
                    }
                    hidden.MergeAttributes(helper.GetUnobtrusiveValidationAttributes(options.SelectIdName, metadata));
                    selectString.Append(helper.ValidationMessage(metadata.PropertyName));
                }
                selectString.Append(hidden.ToString(TagRenderMode.Normal));
            }
            return new MvcHtmlString(selectString.ToString());
        }

        /// <summary>
        /// 根据实体生成级联下拉菜单
        /// </summary>
        /// <typeparam name="TModel">页面实体</typeparam>
        /// <typeparam name="TProperty">属性</typeparam>
        /// <param name="helper">页面帮助类</param>
        /// <param name="expression">属性表达式</param>
        /// <param name="options">配置信息</param>
        /// <param name="tree">要绑定的树列表</param>
        /// <returns>HTML字符串</returns>
        /// 创 建 者：Loamen.com
        public static MvcHtmlString MutiSelectFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, MutiOptions options, IList<Tree> tree)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            if (string.IsNullOrWhiteSpace(options.SelectIdName))
            {
                options.SelectIdName = name;
            }
            return MutiSelect(helper, options, tree);
        }

        /// <summary>
        /// 递归创建下拉列表
        /// </summary>
        /// <param name="selectString">字符串对象</param>
        /// <param name="options">参数设置</param>
        /// <param name="tree">树列表</param>
        /// <param name="selectedValue">选中的值</param>
        /// 创 建 者：Loamen.com
        private static void CreateSelect(StringBuilder selectString, MutiOptions options, IList<Tree> tree, ref string selectedValue, int currentDepth)
        {
            //深度控制
            if (options.Depth.HasValue && options.Depth.Value < currentDepth)
            {
                return;
            }
            else
            {
                currentDepth++;
            }
            //初始化子列表
            IList<Tree> childs = null;
            //创建一个Select标签
            TagBuilder select = new TagBuilder("select");
            //根据参数设置标签的属性，客户端根据这些属性加载列表数据
            select.MergeAttribute("data-mutiselect-url", options.Url);
            select.MergeAttribute("class", "marin_r5");
            if (!String.IsNullOrWhiteSpace(options.SelectName))
            {
                select.MergeAttribute("data-mutiselect-selectName", options.SelectName);
            }
            else
            {
                select.MergeAttribute("data-mutiselect-selectName", "");
            }
            if (options.Depth.HasValue)
            {
                select.MergeAttribute("data-mutiselect-depth", options.Depth.Value.ToString());
            }
            else
            {
                select.MergeAttribute("data-mutiselect-depth", "");
            }
            if (!string.IsNullOrWhiteSpace(options.Exceptions))
            {
                select.MergeAttribute("data-mutiselect-exceptions", options.Exceptions);
            }
            else
            {
                select.MergeAttribute("data-mutiselect-exceptions", "");
            }

            //是否禁用
            if (options.IsDisabled)
            {
                //当前深度从1开始的（有深度的,表示不完全禁用）
                if (options.Depth.HasValue && options.Depth.Value >= currentDepth)
                    select.MergeAttribute("Disabled", "Disabled");
                //没有深度 全部禁用
                if (!options.Depth.HasValue)
                    select.MergeAttribute("Disabled", "Disabled");
            }

            //下拉框 change 事件
            if (!string.IsNullOrWhiteSpace(options.ItemChange))
            {
                select.MergeAttribute("data-mutiselect-itemchange", options.ItemChange);
            }

            if (!String.IsNullOrWhiteSpace(options.ValueField))
            {
                select.MergeAttribute("data-mutiselect-valueField", options.ValueField);
            }

            if (!String.IsNullOrWhiteSpace(options.TextDatField))
            {
                select.MergeAttribute("data-mutiselect-textField", options.TextDatField);
            }

            if (!String.IsNullOrWhiteSpace(options.DataType))
            {
                select.MergeAttribute("data-mutiselect-dataType", options.DataType);
            }

            if (!String.IsNullOrWhiteSpace(options.SelectIdName))
            {
                select.MergeAttribute("data-mutiselect-selectedId", options.SelectIdName);
            }

            if (!String.IsNullOrWhiteSpace(options.SelectIdName))
            {
                select.MergeAttribute("data-mutiselect-selectName", options.SelectName);
            }

            if (!String.IsNullOrWhiteSpace(options.ParaName))
            {
                select.MergeAttribute("data-mutiselect-parentParaName", options.ParaName);
            }

            if (!String.IsNullOrWhiteSpace(options.RequestType))
            {
                select.MergeAttribute("data-mutiselect-type", options.RequestType);
            }

            if (!String.IsNullOrWhiteSpace(options.EmptyText))
            {
                select.MergeAttribute("data-mutiselect-emptyItem-text", options.EmptyText);
            }

            if (options.EmptyValue != null)
            {
                select.MergeAttribute("data-mutiselect-emptyItem-value", options.EmptyValue);
                select.MergeAttribute("data-mutiselect-emptyItem-enable", "true");
            }

            selectString.Append(select.ToString(TagRenderMode.StartTag));
            TagBuilder option;
            if (options.EmptyValue != null)
            {
                option = new TagBuilder("option");
                option.Attributes["value"] = options.EmptyValue;
                option.SetInnerText(options.EmptyText);
                selectString.Append(option.ToString());
            }
            //循环列表加载Option
            foreach (var item in tree)
            {
                option = new TagBuilder("option");
                option.Attributes["value"] = item.Id;
                if (item.Selected)
                {
                    option.Attributes["selected"] = item.Selected.ToString();
                    selectedValue = item.Id;
                }
                option.SetInnerText(item.Name);
                selectString.Append(option.ToString());
                if (item.Childs != null && item.Childs.Count != 0)
                {
                    childs = item.Childs;
                }
            }
            //加入结束标签
            selectString.Append(select.ToString(TagRenderMode.EndTag));
            if (childs != null && childs.Count > 0)
            {
                //递归加载子级
                CreateSelect(selectString, options, childs, ref selectedValue, currentDepth);
            }
        }

        /// <summary>
        /// 将列表转换成树结构
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">列表</param>
        /// <param name="convert">转换方法</param>
        /// <returns>树列表</returns>
        /// 创 建 者：Loamen.com
        public static IList<Tree> ForTree<T>(this IEnumerable<T> source, Func<T, Tree> convert)
        {
            //初始化列表
            IList<Tree> sourceList = new List<Tree>();
            //将源数据转换为树列表
            foreach (var item in source)
            {
                sourceList.Add(convert(item));
            }
            //查询根目录菜单
            IList<Tree> treeList = sourceList.Where(m => String.IsNullOrWhiteSpace(m.ParentId)).ToList();
            treeList.Each(m => sourceList.Remove(m));
            //循环加载子节点
            foreach (var item in treeList)
            {
                if (!sourceList.Any(m => m.ParentId.ToString() == item.Id)) continue;
                getChilds(sourceList, item);
            }
            return treeList;
        }

        /// <summary>
        /// 获取 具有层次结构的树形
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="convert"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static IList<Tree> ForDropList<T>(this IEnumerable<T> source, Func<T, Tree> convert)
        {
            //初始化列表
            IList<Tree> sourceList = new List<Tree>();
            //将源数据转换为树列表
            foreach (var item in source)
            {
                sourceList.Add(convert(item));
            }
            //查询根目录菜单
            IList<Tree> treeList = sourceList.Where(m => m.ParentId == null || m.ParentId == "").ToList();
            //需要返回的 有父子节的树
            IList<Tree> backTree = new List<Tree>();
            //循环加载子节点
            foreach (var item in treeList)
            {
                if (!sourceList.Any(m => m.ParentId.ToString() == item.Id))
                {
                    backTree.Add(item);
                    continue;
                }
                backTree = backTree.Concat(GetChilds(sourceList, item)).ToList();
            }
            return backTree;
        }

        /// <summary>
        /// 读取子节点
        /// </summary>
        /// <param name="sourceList">数据源列表</param>
        /// <param name="item">当前项</param>
        /// 创 建 者：Loamen.com
        private static void getChilds(IList<Tree> sourceList, Tree item)
        {
            var tempList = sourceList.Where(m => m.ParentId.ToString() == item.Id).ToList();
            if (tempList == null || tempList.Count == 0) return;
            item.Childs = new List<Tree>();
            item.Childs.AddRange(tempList);
            foreach (var node in tempList)
            {
                if (!sourceList.Any(m => m.ParentId.ToString() == node.Id)) continue;
                getChilds(sourceList, node);
            }
        }

        /// <summary>
        /// 读取子节点
        /// </summary>
        /// <param name="sourceList">数据源列表</param>
        /// <param name="item">当前项</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        private static IList<Tree> GetChilds(IList<Tree> sourceList, Tree item)
        {
            var tempList = sourceList.Where(m => m.ParentId.ToString() == item.Id).ToList();

            IList<Tree> returnList = new List<Tree>();

            returnList.Add(item);

            foreach (var node in tempList)
            {
                if (!sourceList.Any(m => m.ParentId.ToString() == node.Id))
                {
                    returnList.Add(node);
                    continue;
                }

                returnList = returnList.Concat(GetChilds(sourceList, node)).ToList();
            }
            return returnList;
        }
    }
}
