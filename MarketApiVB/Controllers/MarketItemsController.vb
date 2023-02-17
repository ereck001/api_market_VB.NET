
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports MarketApiVB.MaketApi.Data
Imports MarketApiVB.MaketApi.Models


Namespace Controllers
    Public Class MarketItemsController
        Inherits ApiController

        Private context As New MarketDataContext

        ' GET: api/MarketItems
        Function GetMarketItems() As IQueryable(Of MarketItem)
            Return context.MarketItems
        End Function

        ' GET: api/MarketItems/5
        <ResponseType(GetType(MarketItem))>
        Async Function GetMarketItem(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim marketItem As MarketItem = Await context.MarketItems.FindAsync(id)
            If IsNothing(marketItem) Then
                Return NotFound()
            End If

            Return Ok(marketItem)
        End Function

        ' PUT: api/MarketItems/5
        <ResponseType(GetType(Void))>
        Async Function PutMarketItem(ByVal id As Integer, ByVal marketItem As MarketItem) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If id <> marketItem.Id Then
                Return BadRequest()
            End If

            context.Entry(marketItem).State = EntityState.Modified

            Try
                Await context.SaveChangesAsync()
            Catch ex As DbUpdateConcurrencyException
                If Not (MarketItemExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/MarketItems
        <ResponseType(GetType(MarketItem))>
        Async Function PostMarketItem(ByVal marketItem As MarketItem) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            context.MarketItems.Add(marketItem)
            Await context.SaveChangesAsync()

            Return CreatedAtRoute("DefaultApi", New With {.id = marketItem.Id}, marketItem)
        End Function

        ' DELETE: api/MarketItems/5
        <ResponseType(GetType(MarketItem))>
        Async Function DeleteMarketItem(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim marketItem As MarketItem = Await context.MarketItems.FindAsync(id)
            If IsNothing(marketItem) Then
                Return NotFound()
            End If

            context.MarketItems.Remove(marketItem)
            Await context.SaveChangesAsync()

            Return Ok(marketItem)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                context.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function MarketItemExists(ByVal id As Integer) As Boolean
            Return context.MarketItems.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace