using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string? PostedBy { get; set; }

    public DateTime PostDate { get; set; }

    public byte? QuestionTypeId { get; set; }

    public byte ReviewStatus { get; set; }

    public string? ReviewedBy { get; set; }

    public DateTime ReviewDate { get; set; }

    public string? IsAccepted { get; set; }

    public byte? ComplexityLevel { get; set; }

    public string? IsActive { get; set; }

    public byte? CategoryId { get; set; }

    public virtual AudioQuestion? AudioQuestion { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<McqQuestion> McqQuestions { get; } = new List<McqQuestion>();

    public virtual User? PostedByNavigation { get; set; }

    public virtual QuestionType? QuestionType { get; set; }

    public virtual User? ReviewedByNavigation { get; set; }
}
