using System.Collections.Generic;


namespace AuthAndApi.Aspnet4.Configuration {

    public class Driver {

        public string Class { get; set; }

        public string Name { get; set; }

        public string OwnerClass { get; set; }

        public IEnumerable<DriverParameter> Parameters { get; set; }

    }

}
