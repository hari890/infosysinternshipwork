using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class McqQuestion
{
    public int McqquestionId { get; set; }

    public int? QuestionId { get; set; }

    public string QustionDesc { get; set; } = null!;

    public int? Option1 { get; set; }

    public int? Option2 { get; set; }

    public int? Option3 { get; set; }

    public int Answer { get; set; }

    public virtual Question? Question { get; set; }
}
