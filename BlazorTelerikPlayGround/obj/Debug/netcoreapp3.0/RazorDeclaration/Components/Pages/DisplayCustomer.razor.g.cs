#pragma checksum "C:\Users\peter\Source\Repos\BlazorTelerikPlayground\Components\Pages\DisplayCustomer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "186b76c0eb7e77144020fa01f5720d9a6ac5504e"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorTelerikPlayground.Components.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.Layouts;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.JSInterop;
    using BlazorTelerikPlayground.Components.Shared;
    using Customers.Common;
    using Kendo.Blazor.Components.Grid;
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Components.RouteAttribute("/displaycustomers")]
    public class DisplayCustomer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 20 "C:\Users\peter\Source\Repos\BlazorTelerikPlayground\Components\Pages\DisplayCustomer.razor"
            

    private KendoGrid<Customer> grid { get; set; }
    private string status = "Ready";
    private IEnumerable<Customer> customers = null;

    protected override void OnAfterRender()
    {
        GetCustomers();
        grid.Data = customers;
        grid.Pageable = true;
        base.OnAfterRender();
    }


    public async void GetCustomers()
    {
        HttpClient hc = new HttpClient();
        HttpResponseMessage rm = await hc.GetAsync("https://localhost:5001/customers");
        customers = await rm.Content.ReadAsAsync<IEnumerable<Customer>>();
        if (rm.IsSuccessStatusCode)
        {
            status = "Retrieved";
        }
        else
        {
            status = rm.StatusCode.ToString();
        }
        StateHasChanged();
    }

    public async void SaveCustomers()
    {

        HttpClient hc = new HttpClient();

        HttpResponseMessage rm = await hc.PutAsJsonAsync("https://localhost:5001/customers", customers.First());
        if (rm.IsSuccessStatusCode)
        {
            status = "Updated";
        }
        else
        {
            status = rm.StatusCode.ToString();
        }
        StateHasChanged();
    }
    private void Page()
    {
        grid.Page = 2;
        StateHasChanged();
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
