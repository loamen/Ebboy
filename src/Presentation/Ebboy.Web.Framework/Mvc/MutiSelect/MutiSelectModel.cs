using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Web.Framework.Mvc
{
    /// <summary>
    /// 树结构实体类
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父节点编号
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// 子节点列表
        /// </summary>
        public List<Tree> Childs { get; set; }

        /// <summary>
        /// 是否含有子节点
        /// </summary>
        public bool HasChild
        {
            get
            {
                return Childs != null && Childs.Count > 0;
            }
        }
    }

    /// <summary>
    /// 多选框设置
    /// </summary>
    public class MutiOptions
    {
        /// <summary>
        /// 异步访问地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 异步访问的深度
        /// </summary>
        public int? Depth { get; set; }

        /// <summary>
        /// 异步访问的深度例外的layerName字符串
        /// </summary>
        public string Exceptions { get; set; }

        /// <summary>
        /// 选择编号隐藏域的ID
        /// </summary>
        public string SelectIdName { get; set; }

        /// <summary>
        /// 列表名字
        /// </summary>
        public string SelectName { get; set; }

        /// <summary>
        /// 返回数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 文本字段名称
        /// </summary>
        public string TextDatField { get; set; }

        /// <summary>
        /// 值字段名称
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// 列表框选中参数名字
        /// </summary>
        public string ParaName { get; set; }

        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestType { get; set; }

        /// <summary>
        /// 空节点文本
        /// </summary>
        public string EmptyText { get; set; }

        /// <summary>
        /// 空节点值
        /// </summary>
        public string EmptyValue { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        ///  下拉框 change事件
        /// </summary>
        public string ItemChange { get; set; }
    }
}
