﻿Public Class Order
    'Hidden variables/methods/dates
    Private m_Product As String = "ModelX"
    Private m_ID As String = "ORD01"

    'Properties
    Public Property OrderAmount As Integer = 10

    Public Property OrderDate As Date = Now()

    Public Property OrderDue As Date = Now.AddDays(7)

    Public Property LeadTime As TimeSpan = OrderDue.Subtract(Now)

    Public Property IsDefault As Boolean = True

    Public Property IsRepeated As Boolean = True

    'Constructor
    Public Sub New()

    End Sub

    Public Sub New(product As String)
        Me.Product = product
    End Sub

    Public Property Product As String
        Get
            Return m_Product
        End Get
        Set(value As String)
            m_Product = value
        End Set
    End Property

    Public Property ID As String
        Get
            Return m_ID
        End Get
        Set(value As String)
            m_ID = value
        End Set
    End Property

    Public Shared Function IsValidDueDate(dtp As DateTimePicker) As Boolean
        Try
            If dtp.Value < Now.AddDays(1) Then
                Throw New Exception("Due date should be at least 24 hours from now")
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Due date error")
            Return False
        End Try
    End Function

    Public Function GetOrderSummary() As String
        Dim str As String =
            "Product name: " & vbTab & Me.Product & vbCrLf &
            "Order amount: " & vbTab & Me.OrderAmount & vbCrLf &
            "Order date: " & vbTab & Me.OrderDate.ToString & vbCrLf &
            "Order due: " & vbTab & Me.OrderDue.ToString & vbCrLf &
            "Lead time: " & vbTab & Me.LeadTime.Days & vbCrLf &
            "Default: " & vbTab & Me.IsDefault.ToString & vbCrLf &
            "Repeated: " & vbTab & Me.IsRepeated.ToString & vbCrLf

        Return str
    End Function

    Public Function GetOrderSummary(ord As String) As String
        Dim str As String = "ID: " & vbTab & ord & vbCrLf & GetOrderSummary()

        Return str
    End Function

End Class
