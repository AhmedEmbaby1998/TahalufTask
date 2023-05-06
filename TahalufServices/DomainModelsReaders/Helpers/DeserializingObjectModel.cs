using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModelsReaders.Helpers
{
    internal class DeserializingObjectModel
    {
        internal IEnumerable<DomainSourceBindings>? DomainSourceBindings { set; get; }
    }

    internal class DomainSourceBindings
    {
        internal Entity? Entity { set; get; }
    }
    internal class Entity
    {
        internal string? Name { set; get; }
        internal IEnumerable<Attribute>? Attributes { set; get; }
    }
    internal class Attribute
    {
        internal string? Name { get; set; }
    }
}
