using DemoShop.DAL;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Infrastructure
{
    public class DetailCategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        private DemoShopContext db = new DemoShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var Value = new List<DynamicNode>();
            // Create a node for each album 
            foreach (var product in db.Categories)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = product.Title;
                dynamicNode.Key = "Category_" + product.CategoryID;
                dynamicNode.RouteValues.Add("categoryname", product.Title);
                Value.Add(dynamicNode);

            }
            return Value;
        }
    }
}