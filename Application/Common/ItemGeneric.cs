using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common;
public sealed record ItemGeneric<TypeOne, TypeTwo>
{
    public TypeOne? Id { get; set; }
    public TypeTwo? Title { get; set; }
}