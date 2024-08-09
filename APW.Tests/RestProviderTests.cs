using APW.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APW.Tests;

public class RestProviderTests()
{
    private readonly RestProvider _restProvider = new RestProvider();

    [Fact]
    public void Test1()
    {
        var result = _restProvider.GetAsync("https://api.restful-api.dev/objects", null);
        Assert.NotNull(result);
    }
}
