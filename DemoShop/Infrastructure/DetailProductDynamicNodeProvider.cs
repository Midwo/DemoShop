using DemoShop.DAL;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Infrastructure
{
    public class DetailProductDynamicNodeProvider : DynamicNodeProviderBase
    {
        private DemoShopContext db = new DemoShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var Value = new List<DynamicNode>();
            // Create a node for each album 
            foreach (var product in db.Products)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = product.ProductTitle;
                dynamicNode.Key = "Product_" + product.ProductID;
                dynamicNode.ParentKey = "Category_" + product.CategoryID;
                dynamicNode.RouteValues.Add("id", product.ProductID);
                Value.Add(dynamicNode);
                
            }
            return Value;
        }
    }
}
