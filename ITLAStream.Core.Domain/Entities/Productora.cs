using ITLAStream.Core.Domain.Common;

namespace ITLAStream.Core.Domain.Entities;

public class Productora : ModeloBase
{
    public ICollection<Series> Serie { get; set; }
}