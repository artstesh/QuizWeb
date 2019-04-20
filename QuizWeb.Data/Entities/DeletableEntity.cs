using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    public abstract class DeletableEntity : BaseEntity
    {
        [Column("IsDeleted")] public bool IsDeleted { get; set; }
    }
}