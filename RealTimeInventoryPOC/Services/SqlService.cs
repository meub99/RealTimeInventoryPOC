using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealTimeInventoryPOC.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;


//This Sample Code is provided for the purpose of illustration only and is not intended to be used in a production environment.
//THIS SAMPLE CODE AND ANY RELATED INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//We grant You a nonexclusive, royalty-free right to use and modify the Sample Code and to reproduce and distribute the 
//object code form of the Sample Code, provided thatYou agree: (i)to not use Our name, logo, or trademarks to marketYour software 
//product in which the Sample Code is embedded; (ii) to include a valid copyright notice on Yoursoftware product in which the Sample Code is embedded;
//and(iii)to indemnify, hold harmless, and defend Us and Our suppliers from and against any claims or lawsuits, including attorneys’ 
//fees, that arise or result from the use or distribution of the Sample Code.
//  Please note: None of the conditions outlined in the disclaimer above will supersede the terms and conditions contained within the Premier Customer Services Description.

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
