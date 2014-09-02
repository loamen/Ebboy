using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebboy.Web.Framework.Mvc
{
    /// <summary>
    /// Ebboy视图实体基类
    /// </summary>
    public partial class BaseEbboyModel
    {
        public BaseEbboyModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
        }
        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// 自定义属性
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    /// <summary>
    /// Ebboy视图实体基类
    /// </summary>
    public partial class BaseEbboyEntityModel : BaseEbboyModel
    {
        public virtual int Id { get; set; }
    }
}
