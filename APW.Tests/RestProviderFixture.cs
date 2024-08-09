using APW.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APW.Tests;

public class RestProviderFixture : IDisposable
{
    public IRestProvider RestProvider { get; private set; }

    public RestProviderFixture()
    {
        RestProvider = new RestProvider();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
