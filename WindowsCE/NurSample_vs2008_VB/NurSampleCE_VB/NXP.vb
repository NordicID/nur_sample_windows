Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class NXP
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Sets the hadle of nur API.
    ''' </summary>
    ''' <param name="hNur">Handle of NurApi.</param>
    Public Sub SetNurApi(ByVal hNur As NurApi)
        Me.Enabled = True
        nxpProductStatusFlag.SetNurApi(hNur)
        nxpEasAlarm.SetNurApi(hNur)
        nxpReadProtect.SetNurApi(hNur)
    End Sub
End Class
