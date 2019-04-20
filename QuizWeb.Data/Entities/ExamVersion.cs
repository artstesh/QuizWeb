using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("exam_version")]
    public class ExamVersion : BaseEntity
    {
        [Column("Version")] public string Version { get; set; }
    }
}