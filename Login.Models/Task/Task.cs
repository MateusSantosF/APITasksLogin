using Login.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Models
{
    public class Task
    {

        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public bool HasChecked { get; set; }

        public User User { get;  set; }

        [ForeignKey("userId")]
        public string UserId { get; set; }

       
    }
}
