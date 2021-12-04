using System.Linq;

namespace csharp
{
    public class BusinessLogicLayer
    {
        public static List<Order> GetOrderGroup() {
            List<Order> myList = DataAccessLayer.GetOrders();
            var urdun = myList.GroupBy(o => o.OrderDate).ToList();
            foreach(var i in urdun) {
                foreach(var j in i) {
                    myList.Add(j);
                }
            }
            return myList;
        }
        public static List<NewItem> GetProductsJoin() {
            List<Product> products = DataAccessLayer.GetProducts();
            List<OrderDetail> orderDetails = DataAccessLayer.GetOrderDetails();
            List<NewItem> myList = new List<NewItem>();
            var urdun = products.Join(
                orderDetails,
                p => p.ProductID,
                o => o.ProductID,
                (p, o) => new {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Quantity = o.Quantity,
                    UnitPrice = o.UnitPrice,
                }
            ).OrderByDescending(o => o.Quantity);
            foreach(var item in urdun) {
                NewItem nItem = new NewItem();
                nItem.ProductID = item.ProductID;
                nItem.ProductName = item.ProductName;
                nItem.Quantity = item.Quantity;
                nItem.UnitPrice = item.UnitPrice;
                myList.Add(nItem);
            }
            return myList;
        }
        public static List<NewItem> SumPrice() {
            List<NewItem> products = GetProductsJoin();
            List<NewItem> myList = new List<NewItem>();
            products.Reverse();
            for (int i = 0; i < 3; i++)
            {
                myList.Add(products[i]);
            }
            return myList;
        }
    }
    public struct NewItem {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice {get;set;}
    }
}