using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.businessLogic
{
    public class DatabaseClass
    {
        public przychodniaEntities db {  get; set; }

        public DatabaseClass(przychodniaEntities db) { 
            this.db = db;
        }
    }
}
