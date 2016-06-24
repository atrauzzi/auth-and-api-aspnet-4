using System.ComponentModel.DataAnnotations;


namespace AuthAndApi.Aspnet4 {

    public class ExternalLogin {

        [Required]
        public string Code { get; set; }

        public string State { get; set; }

    }

}
