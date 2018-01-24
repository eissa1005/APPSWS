using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPSWS.DAL
{
    public class Cars
    {
        public int ID { get; set; }
        public string CAR_Brand { get; set; }
        public string CAR_Type { get; set; }
        public string CAR_Status { get; set; }
        public string Category_Type { get; set; }
        public string CAR_Model { get; set; }
        public string Check_Status { get; set; }
        public string Colors { get; set; }
        public string Car_Size { get; set; }
        public string CAR_Photo { get; set; }
        public string Check_Photo { get; set; }
        public string City { get; set; }
        public string Pay_Type { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public Nullable<Decimal> CAR_Price { get; set; }
        public string CAR_No { get; set; }
        public string Check_Date { get; set; }
    }
}