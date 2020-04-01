#pragma checksum "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\Pages\OrderDetails.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ecd7a97a99fc3324449295db5b5b3a899ff9d34"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazingPizza.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 3 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 4 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 5 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 6 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 7 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 8 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using BlazingPizza.Client;

#line default
#line hidden
#line 9 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using BlazingPizza.Client.Shared;

#line default
#line hidden
#line 10 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\_Imports.razor"
using BlazingPizza.ComponentsLibrary;

#line default
#line hidden
#line 2 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\Pages\OrderDetails.razor"
using System.Threading;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/myorders/{orderId:int}")]
    public partial class OrderDetails : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 36 "D:\xampp\htdocs\cesi\dotnet-csharp-xamarin\web-assembly\PizzeriaWebApplication\BlazingPizza.Client\Pages\OrderDetails.razor"
       
    [Parameter] public int OrderId { get; set; }

    OrderWithStatus orderWithStatus;
    bool invalidOrder;
    CancellationTokenSource pollingCancellationToken;

    protected override void OnParametersSet()
    {
        // If we were already polling for a different order, stop doing so
        pollingCancellationToken?.Cancel();

        // Start a new poll loop
        PollForUpdates();
    }

    private async void PollForUpdates()
    {
        pollingCancellationToken = new CancellationTokenSource();
        while (!pollingCancellationToken.IsCancellationRequested)
        {
            try
            {
                invalidOrder = false;
                orderWithStatus = await HttpClient.GetJsonAsync<OrderWithStatus>($"orders/{OrderId}");
            }
            catch (Exception ex)
            {
                invalidOrder = true;
                pollingCancellationToken.Cancel();
                Console.Error.WriteLine(ex);
            }

            StateHasChanged();

            await Task.Delay(4000);
        }
    }

    void IDisposable.Dispose()
    {
        pollingCancellationToken?.Cancel();
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient HttpClient { get; set; }
    }
}
#pragma warning restore 1591
