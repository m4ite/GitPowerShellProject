using System;
using System.Collections.Generic;

namespace GitPsProject.Model;

public partial class Repositorio
{
    public int Id { get; set; }

    public string? Diretorio { get; set; }

    public DateTime? DataAtualização { get; set; }
}
