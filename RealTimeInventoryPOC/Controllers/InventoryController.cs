using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealTimeInventoryPOC.Models;
using RealTimeInventoryPOC.Services;
using System.Configuration;


//This Sample Code is provided for the purpose of illustration only and is not intended to be used in a production environment.
//THIS SAMPLE CODE AND ANY RELATED INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//We grant You a nonexclusive, royalty-free right to use and modify the Sample Code and to reproduce and distribute the 
//object code form of the Sample Code, provided thatYou agree: (i)to not use Our name, logo, or trademarks to marketYour software 
//product in which the Sample Code is embedded; (ii) to include a valid copyright notice on Yoursoftware product in which the Sample Code is embedded;
//and(iii)to indemnify, hold harmless, and defend Us and Our suppliers from and against any claims or lawsuits, including attorneys’ 
//fees, that arise or result from the use or distribution of the Sample Code.
//  Please note: None of the conditions outlined in the disclaimer above will supersede the terms and conditions contained within the Premier Customer Services Description.
namespace RealTimeInventoryPOC.Controllers
{
    public class InventoryController : ApiController
    {
        //private SqlService inventory;

        //public InventoryController()
        //{           
        //    //this.inventory = new SqlService();
        //}

        public IEnumerable <Inventory> Get()
        {
            var inventory = new SqlService(ConfigurationManager.ConnectionStrings["PrimarySql"].ConnectionString);
            return inventory.GetAllInventory();
            //return this.inventory.GetAllInventory();

        }

  
        public Inventory Get(int id)
        {
            var service = new SqlService(ConfigurationManager.ConnectionStrings["PrimarySql"].ConnectionString);
            var inventory = service.GetInventorybySku(id);
            
            if (inventory == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);

            return inventory;

        }

    }
}
