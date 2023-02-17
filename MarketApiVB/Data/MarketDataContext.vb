Imports System.Data.Entity
Imports MarketApiVB.MaketApi.Models

Namespace MaketApi.Data
    Public Class MarketDataContext
        Inherits DbContext
        Public Sub New()
            MyBase.New("Server=localhost,1433;Database=MarketApi;User ID=sa;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True")
        End Sub

        Public Property MarketItems As DbSet(Of MarketItem)
    End Class
End Namespace
