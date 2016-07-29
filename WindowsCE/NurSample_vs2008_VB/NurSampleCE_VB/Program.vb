Imports System.Collections.Generic
Imports System.Windows.Forms

NotInheritable Class Program
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Return name of application
    ''' </summary>
    Public Shared ReadOnly Property appName() As String
        Get
            Return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString()
        End Get
    End Property

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <MTAThread()> _
    Friend Shared Sub Main()
        Try
            Application.Run(New Form1())
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub
End Class
