using System;
using System.Collections.Generic;

namespace NewProjectEF.BusinessEntities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;
    public string UserName { get; internal set; }
    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Role { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
