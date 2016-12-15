using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealTimeInventoryPOC.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;




namespace RealTimeInventoryPOC.Services
{
    public class SqlService
    {
        #region setup

        private readonly string _connection;
        private IDbConnection connection = null;
        private readonly string connectionString = null;

        public SqlService(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        #endregion
             
        public IEnumerable<Inventory> GetAllInventory()
        {
            return connection.Query<Inventory>("SELECT * FROM dbo.Inventory");

            //return new Inventory[]
            //{
            //  new Inventory
            //{
            //    Sku = 1234,
            //    Product = "Sweater",
            //    Quantity = 5
            //},
            //new Inventory
            //{
            //    Sku = 5678,
            //    Product = "Pants",
            //    Quantity = 10
            //},
        }

        public Inventory GetInventorybySku(int Sku)
        {
            return connection.Query<Inventory>("SELECT * FROM Inventory WHERE Sku =" + Sku).FirstOrDefault();
        }

        

        //}

        //public Inventory GetInventorybySku(int sku)
        //{
        //    return null;
    }



}
