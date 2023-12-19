using System;
using System.Collections.Generic;

namespace WPFDataGrid_Example.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Dob { get; set; }

    public string BookTitle { get; set; }

    public bool IsMvp { get; set; }
}
