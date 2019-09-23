using application.API.Definitions.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.API.Models
{
    public class Post: IModel
    {
        [Key]
        [StringLength(36)]
        public string Id {get; set;}
        [StringLength(64)]
        [Required]
        public string  Title { get; set; }
        public string  Body { get; set; }
                [Required]
        public string  State { get; set; }
        public DateTime  CreationDate { get; set; }

        [StringLength(36)]
        public string ClientId {get; set;}

        [ForeignKey(nameof(ClientId))]
        public AppUser Client { get; set; }
    }
}