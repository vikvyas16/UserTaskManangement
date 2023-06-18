using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskManagement.Common.Configuration
{
    public interface  IAppSetting
    {
        string DbConnection { get; }
        //string UpdateProduct { get; }
        //string GetProductLookUp { get; }
        //string GetProductById { get; }
        //string GetProductCategory { get; }
        //string GetProductAttributeLookUpByCategoryId { get; }
        //string AddProductAttributes { get; }
        string AddUser { get; }
    }
}
