using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Models;

namespace TestAutomation.Service
{
    class BookingInfoCreater
    {
        public static BookingInfo RightBookingInfo()
        {
            return new BookingInfo(
                TestDataReader.GetData("Name"),
                TestDataReader.GetData("Phone"),
                TestDataReader.GetData("City"),
                TestDataReader.GetData("DateFrom"),
                TestDataReader.GetData("DateTo")
                );
        }

        public static BookingInfo WrongBookingInfo()
        {
            return new BookingInfo(
                TestDataReader.GetData("IncorrectName"),
                TestDataReader.GetData("Phone"),
                TestDataReader.GetData("IncorrectCity"),
                TestDataReader.GetData("IncorrectDateFrom"),
                TestDataReader.GetData("IncorrectDateTo")
                );
        }
    }
}
