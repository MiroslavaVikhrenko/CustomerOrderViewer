using CustomerOrderViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer.Repository
{
    //for connecting to the SQL server instance 
    internal class CustomerOrderDetailCommand
    {
        //private field
        private string _connectionString;

        //constructor which takes a connectiong string as a parameter
        public CustomerOrderDetailCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        //A public method to return a list of customer order detail models
        public IList<CustomerOrderDetailModel> GetList()
        {
            //'List' is a concreate version, 'IList' is an abstract version => best practice 
            List<CustomerOrderDetailModel> customerOrderDetailModels = new List<CustomerOrderDetailModel>();
            //so far it's an empty list
            return customerOrderDetailModels;
        }
    }
}
