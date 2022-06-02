using SuperFormulaRestAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFormulaRestAPITests.WebHost.Models
{
    public class PayloadTestClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<Payload>()
                {
                    new Payload()
                    {
                        FirstName = "Testfirstname",
                        LastName = "Testlastname",
                        EffectiveDate = DateTime.Now.AddDays(31),
                        DriverLicenseNumber = "DL100005",
                        VehicleYear = 1955,
                        VehicleManufacturer = "Honda",
                        VehicleModel = "CRV",
                        VehicleName = "Daily Driver",
                        StreetAddress = "450 W Hamton Rd",
                        City = "Richmond",
                        State = "VA",
                        Zip = "23224",
                        ExpirationDate = DateTime.Now.AddDays(61),
                        Premium = 95.89
                    },
                    new Payload()
                    {
                        FirstName = "Testfirstname",
                        LastName = "Testlastname",
                        EffectiveDate = DateTime.Now.AddDays(31),
                        DriverLicenseNumber = "DL100006",
                        VehicleYear = 1955,
                        VehicleManufacturer = "Honda",
                        VehicleModel = "CRV",
                        VehicleName = "Daily Driver",
                        StreetAddress = "450 W Hamton Rd",
                        City = "Richmond",
                        State = "VA",
                        Zip = "23224",
                        ExpirationDate = DateTime.Now.AddDays(61),
                        Premium = 95.89
                    },
                    new Payload()
                    {
                        FirstName = "Testfirstname",
                        LastName = "Testlastname",
                        EffectiveDate = DateTime.Now.AddDays(31),
                        DriverLicenseNumber = "DL100007",
                        VehicleYear = 1955,
                        VehicleManufacturer = "Honda",
                        VehicleModel = "CRV",
                        VehicleName = "Daily Driver",
                        StreetAddress = "450 W Hamton Rd",
                        City = "Richmond",
                        State = "VA",
                        Zip = "23224",
                        ExpirationDate = DateTime.Now.AddDays(61),
                        Premium = 95.89
                    }
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
