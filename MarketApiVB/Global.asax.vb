Imports System.Web.Optimization
Imports System.Web.Http
Public Class MvcApplication
    Inherits HttpApplication

    Protected Sub Application_Start()

        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        AreaRegistration.RegisterAllAreas()
        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
        RegisterBundles(BundleTable.Bundles)

    End Sub
End Class
