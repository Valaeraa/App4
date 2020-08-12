using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}
