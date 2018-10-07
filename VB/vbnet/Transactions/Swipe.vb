﻿' 
' Bluepay VB.NET Sample code.
' 
' This code sample runs a $3.00 sales transaction using the payment information obtained from a credit card swipe.
' If using TEST mode, odd dollar amounts will return an approval and even dollar amounts will return a decline.
' 

Imports System
Imports vbnet.BPVB

Namespace Transactions

    Public Class Swipe

        Public Shared Sub run()

            Dim accountID As String = "Merchant's Account ID Here"
            Dim secretKey As String = "Merchant's Secret Key Here"
            Dim mode As String = "TEST" 

            Dim payment As BluePay = New BluePay(
                accountID,
                secretKey,
                mode
            )

            payment.setCustomerInformation(
                firstName:="Bob",
                lastName:="Tester",
                address1:="123 Test St.",
                address2:="Apt #500",
                city:="Testville",
                state:="IL",
                zipCode:="54321", 
                country:="USA",
                phone:="123-123-12345",
                email:="test@bluepay.com"
            )

            ' Set payment information for a swiped credit card transaction
            payment.swipe("%B4111111111111111^TEST/BLUEPAY^2511101100001100000000667000000?;4111111111111111=251110110000667?")

            payment.sale(amount:="3.00")

            payment.process()

            If payment.isSuccessfulTransaction() Then
                Console.Write("Transaction Status: " + payment.getStatus() + Environment.NewLine)
                Console.Write("Transaction Message: " + payment.getMessage() + Environment.NewLine)
                Console.Write("Transaction ID: " + payment.getTransID() + Environment.NewLine)
                Console.Write("AVS Result: " + payment.getAVS() + Environment.NewLine)
                Console.Write("CVV2 Result: " + payment.getCVV2() + Environment.NewLine)
                Console.Write("Masked Payment Account: " + payment.getMaskedPaymentAccount() + Environment.NewLine)
                Console.Write("Card Type: " + payment.getCardType() + Environment.NewLine)
                Console.Write("Authorization Code: " + payment.getAuthCode() + Environment.NewLine)
            Else
                Console.Write("Transaction Error: " + payment.getMessage() + Environment.NewLine)
            End If
        End Sub
    End Class
End Namespace