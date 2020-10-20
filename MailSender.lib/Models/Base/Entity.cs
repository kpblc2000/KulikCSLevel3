using System.ComponentModel.DataAnnotations;

namespace WpfMailSender.Models.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        [Required, MaxLength(255)]
        public virtual string Name { get; set; }
    }

    public abstract class Person : NamedEntity
    {
        [Required, MaxLength(150)]
        public virtual string Address { get; set; }
    }

}
