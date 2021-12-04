using System.Data.SqlClient;

namespace csharp
{
    public class DataAccessLayer
    {
        private static readonly string constring = @"Data Source=localhost;Initial Catalog=Northwind;User Id=sa; Password=MyPass@word;";
        public static List<Order> GetOrders() {
            List<Order> mylist = new List<Order>();
            SqlConnection con = new SqlConnection(constring);
            if(con.State == System.Data.ConnectionState.Closed) {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Orders", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()) {
                    Order myOrder = new Order();
                    myOrder.OrderID = (int)dr["OrderID"];
                    // myOrder.CustomerID = (string)dr["CustomerID"];
                    // myOrder.EmployeeID = (int)dr["EmployeeID"];
                    myOrder.OrderDate = (DateTime)dr["OrderDate"];
                    // myOrder.RequiredDate = (DateTime)dr["RequiredDate"];
                    // myOrder.ShippedDate = (DateTime)dr["ShippedDate"];
                    // myOrder.ShipVia = (int)dr["ShipVia"];
                    // myOrder.Freight = (decimal)dr["Freight"];
                    // myOrder.ShipName = (string)dr["ShipName"];
                    // myOrder.ShipAddress = (string)dr["ShipAddress"];
                    // myOrder.ShipCity = (string)dr["ShipCity"];
                    // myOrder.ShipRegion = (string)dr["ShipRegion"];
                    // myOrder.ShipPostalCode = (string)dr["ShipPostalCode"];
                    // myOrder.ShipCountry = (string)dr["ShipCountry"];

                    mylist.Add(myOrder);
                }
                con.Close();
            }
            return mylist;
        }
        public static List<OrderDetail> GetOrderDetails() {
            List<OrderDetail> myList = new List<OrderDetail>();
            SqlConnection con = new SqlConnection(constring);
            if(con.State == System.Data.ConnectionState.Closed) {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Order Details]", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()) {
                    OrderDetail item = new OrderDetail();
                    item.OrderID = (int)dr["OrderID"];
                    item.ProductID = (int)dr["ProductID"];
                    item.UnitPrice = (decimal)dr["UnitPrice"];
                    item.Quantity = (Int16)dr["Quantity"];
                    item.Discount = (Single)dr["Discount"];
                    myList.Add(item);
                }
                con.Close();
            }
            return myList;
        }
        public static List<Product> GetProducts() {
            List<Product> myList = new List<Product>();
            SqlConnection con = new SqlConnection(constring);
            if(con.State == System.Data.ConnectionState.Closed) {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Products", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()) {
                    Product item = new Product();
                    item.ProductID = (int)dr["ProductID"];
                    item.ProductName = (string)dr["ProductName"];
                    myList.Add(item);
                }
                con.Close();
            }
            return myList;
        }
    }
    public struct Order {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
    public struct OrderDetail {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }   
        public double Discount { get; set; }
    }
    public struct Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}