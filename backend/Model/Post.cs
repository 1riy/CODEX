﻿using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Publicante { get; set; } = null!;

    public string Conteudo { get; set; } = null!;

    public string Review { get; set; } = null!;
}
