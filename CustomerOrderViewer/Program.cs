using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using Microsoft.Data.SqlClient;

namespace CustomerOrderViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiate CustomerOrderDetailCommand
            CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=localhost;Initial Catalog=CustomerOrderViewer;Integrated Security=True;Encrypt=False");
            
            //Then from that command use GetList()
            IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();
            Console.ReadKey();
        }
    }
}
