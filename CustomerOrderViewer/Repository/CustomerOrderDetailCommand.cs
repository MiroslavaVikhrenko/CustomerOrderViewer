using CustomerOrderViewer.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

            //we initialize the connection in 'using' => the connection will be disposed after we're done using it => otherwise we would be spending resources
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open(); //now we have an open connection =>
                                   //now we know which instance of SQL Server we're connected to
                                   //and we also opened up that connection

                //next we need to send commands => once again we need to use 'using' statement
                using (SqlCommand command = new SqlCommand("SELECT CustomerOrderId, CustomerId, ItemId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail", connection))
                {
                    //instantiate the SQL data reader => once again we use 'using' statement - ExecuteReader() method is going to grab the data from command above,
                    //send it over 'connection' and get back to SQL data reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) //HasRows is a property on the reader => if there are rows then go ahead and read them
                        {
                            while (reader.Read()) //while a reader can read (which is how this method works) - it will read the next row and will stop when there are no records
                            {
                                //now we have access to the reader

                                //create CustomerOrderDetailModel => within this model we're going to put all of the properties that it already has
                                CustomerOrderDetailModel customerOrderDetailModel = new CustomerOrderDetailModel()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    ItemId = Convert.ToInt32(reader["ItemId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])

                                };
                                //adding to the list
                                customerOrderDetailModels.Add(customerOrderDetailModel);

                            }
                        }
                    }
                }
            }
            return customerOrderDetailModels;
        }
    }
}
