using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class AudioQuestion
{
    public int AudioQuestionId { get; set; }

    public int QuestionId { get; set; }

    public string QustionDesc { get; set; } = null!;

    public string AudioFilePath { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
