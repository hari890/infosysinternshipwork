using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class QuestionType
{
    public byte QuestionTypeId { get; set; }

    public string QuestionType1 { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
