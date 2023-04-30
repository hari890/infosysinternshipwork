using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class User
{
    public string Userid { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public byte? RoleId { get; set; }

    public string Gender { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public long? Contact { get; set; }

    public virtual ICollection<Question> QuestionPostedByNavigations { get; } = new List<Question>();

    public virtual ICollection<Question> QuestionReviewedByNavigations { get; } = new List<Question>();

    public virtual Role? Role { get; set; }
}
