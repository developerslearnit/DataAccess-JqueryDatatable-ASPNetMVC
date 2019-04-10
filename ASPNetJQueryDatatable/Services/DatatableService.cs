using ASPNetJQueryDatatable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNetJQueryDatatable.Services
{
    public class DatatableService
    {
        DatatableEntities _db;
        public DatatableService()
        {
            _db = new DatatableEntities();
        }

        public IQueryable<CUSTOMER> GetCustomers()
        {
            return _db.CUSTOMERs;
        }
    }
}