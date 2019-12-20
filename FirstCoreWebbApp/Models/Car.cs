using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebbApp.Models
{
    public class Car
    {

        static int idCunter = 0;
        public static List<Car> carList = new List<Car>();         //public då den kommer utifrån

        public int Id { get; set; }

        public string Brand { get; set; }

        public string ModelName { get; set; }

    }
}
