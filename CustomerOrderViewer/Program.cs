using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using Microsoft.Data.SqlClient;

namespace CustomerOrderViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //instantiate CustomerOrderDetailCommand
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=localhost;Initial Catalog=CustomerOrderViewer;Integrated Security=True;Encrypt=False");

                //Then from that command use GetList()
                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                //Any is Linq => says if the list has anything in it
                if (customerOrderDetailModels.Any())
                {
                    //iterate through the list
                    foreach (CustomerOrderDetailModel customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine("{0}: Fullname: {1} {2} (Id: {3}) - purchased {4} for {5} (Id: {6})",
                            customerOrderDetailModel.CustomerOrderId,
                            customerOrderDetailModel.FirstName,
                            customerOrderDetailModel.LastName,
                            customerOrderDetailModel.CustomerId,
                            customerOrderDetailModel.Description,
                            customerOrderDetailModel.Price,
                            customerOrderDetailModel.ItemId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong {0}", ex.Message); //eg, db is down
            }


            Console.ReadKey();
        }
    }
}
