using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealTimeInventoryPOC.Models;
using RealTimeInventoryPOC.Services;
using System.Configuration;

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
