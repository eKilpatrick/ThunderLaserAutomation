Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Module Network
    Private ReadOnly ipStr As String = "127.0.0.1"
    Private ReadOnly outPort As Integer = 19840
    Private ReadOnly inPort As Integer = 19841
    Private ReadOnly remoteEP As New IPEndPoint(IPAddress.Any, 0)


    Public outClient As UdpClient
    Public inClient As UdpClient

    Public Sub ConnectSockets()
        outClient = New UdpClient(ipStr, outPort)
        inClient = New UdpClient(inPort)
        Form1.txtLog.Text &= "UDP Clients connected" & Environment.NewLine
    End Sub

    Public Sub SendAndReceive(cmd As String)

        Dim cmdBytes As Byte() = Encoding.ASCII.GetBytes(cmd)
        outClient.Send(cmdBytes, cmdBytes.Length)

        Form1.txtLog.Text &= cmd & Environment.NewLine

        Dim bytesRead = inClient.Receive(remoteEP)

        If bytesRead.Length > 0 Then
            Dim stringRead As String = Encoding.ASCII.GetString(bytesRead, 0, bytesRead.Length).Trim()
            Console.WriteLine(stringRead)
            Form1.txtLog.Text &= stringRead & Environment.NewLine
        Else
            Form1.txtLog.Text &= "Nothing read..."
        End If
    End Sub
End Module
